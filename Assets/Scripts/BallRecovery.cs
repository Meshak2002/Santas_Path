using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRecovery : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initPos,initScal;
    private float colRad;
    private Rigidbody rb;

    void Start()
    {
        initPos = transform.position;   
        initScal = transform.localScale;
        colRad = transform.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.y < -2)
        {
            Debug.Log("Fall");
            pushBall.instance.Reset();
            pushBall.instance.grab = false;
            playerLocomotion.instance.animator.SetLayerWeight(1, 0);
            GameObject neu = Instantiate(this.gameObject,initPos,Quaternion.identity);
            neu.transform.localScale = initScal;
            neu.transform.GetComponent<SphereCollider>().radius = colRad;
            rb = neu.transform.GetComponent<Rigidbody>();
            neu.GetComponent<Collider>().enabled = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            Destroy(this.gameObject);
        }
    }
}
