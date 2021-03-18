using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            playerRb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound);
            onGround = false;
            dirtParticles.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            dirtParticles.Play();
            onGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound);
            explosionParticle.Play();
            dirtParticles.Stop();
            gameOver = true;
        }

    }
}
