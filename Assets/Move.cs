using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.z -= 0.1f;
            transform.position = playerPosition;

            Debug.Log("player move forward");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.z += 0.1f;
            transform.position = playerPosition;

            Debug.Log("backward");
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.x += 0.1f;
            transform.position = playerPosition;

            Debug.Log("player move left");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 playerPosition = transform.position;
            playerPosition.x -= 0.1f;
            transform.position = playerPosition;

            Debug.Log("player move right");
        }
    }
}
