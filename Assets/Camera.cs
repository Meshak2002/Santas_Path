using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusCamera : MonoBehaviour{

    GameObject playerObj;
    Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        cameraOffset = new Vector3(0, 1, -4);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            transform.position = playerObj.transform.position + cameraOffset;
        }
    }
}
