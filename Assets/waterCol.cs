using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCol : MonoBehaviour
{
    // Start is called before the first frame update
    public camerFollow cf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            cf.target = this.transform;
        }
    }
}
