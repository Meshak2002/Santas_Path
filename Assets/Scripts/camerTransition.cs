using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    public Vector3 changeRotation = new Vector3(55, 45, 0);
    public Vector3 originalRotation = new Vector3(30, 45, 0);
    [HideInInspector]public Vector3 targetRotation;
    public float rotationSpeed = 2.0f;
    [HideInInspector] public bool enter;
    public bool switchh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            enter = true;
        }
    }
    private void Start()
    {
        if (!switchh)
            targetRotation = changeRotation;
        else
            targetRotation = originalRotation;
    }
    public void Update()
    {
        if (enter)
        {
            Debug.Log("Rotate");
            Quaternion rot = Quaternion.Euler(targetRotation);
            if (Mathf.Round(camera.transform.eulerAngles.x) != Mathf.Round(rot.eulerAngles.x))
                camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, rot, rotationSpeed * Time.deltaTime);
            else
            {
                enter = false;
            }
               
        }
    }
}
