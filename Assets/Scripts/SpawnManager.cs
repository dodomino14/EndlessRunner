using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    public Vector3 spawnPos;
    public float spawnRate;

    private PlayerMovement playerMovementScript;
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObjects", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        if (!playerMovementScript.gameOver)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
