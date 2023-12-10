using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleCol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DestroyedRoot, brokenSphere;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("iceBall"))
        {
            collision.transform.gameObject.SetActive(false);
            DestroyedRoot.SetActive(true);
            brokenSphere.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
