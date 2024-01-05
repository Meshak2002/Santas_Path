using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject notce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if(notce != null)
            {
                notce.SetActive(true);
            }
        }
    }
}
