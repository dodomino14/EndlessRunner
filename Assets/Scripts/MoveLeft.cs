using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public Vector3 movement;
    private PlayerMovement playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.gameOver == false)
        {
            transform.Translate(movement * Time.deltaTime);
        }
    }
}
