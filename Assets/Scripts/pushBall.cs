using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

public class pushBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pBall;
    public Transform oBall;
    private bool hold;
    public bool grab;
    public Transform player;
    Vector3 targetSize;
    public SphereCollider sphereCollider;
    public Rigidbody rBall;
    public static pushBall instance;
    public bool got;

    void Start()
    {
        instance = this;
        player = transform.parent;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hold && playerLocomotion.instance.input.magnitude > 0.1f)
        {

            // Check if the current scale is close enough to the target
            if (pBall.transform.localScale.y<targetSize.y-1)
            {
                pBall.transform.localScale = Vector3.Lerp(pBall.transform.localScale, targetSize, Time.deltaTime);
               // sphereCollider.radius -= Time.deltaTime * .05f;
            }
            else
            {
                
                got = true;
                hold = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "iceBall" && !grab)
        {
            
           // Debug.Log("Ball");
            sphereCollider= other.GetComponent<SphereCollider>();
            sphereCollider.enabled = false;
            rBall = other.transform.GetComponent<Rigidbody>();
            playerLocomotion.instance.animator.SetLayerWeight(1, 1);
            oBall = other.transform;
            Quaternion targetRot = Quaternion.LookRotation(oBall.position - player.position, Vector3.up);
            targetRot *= Quaternion.Euler(1, 10, 1);
            player.rotation = targetRot;

            GameObject gO = transform.parent.transform.Find("PivotBall").gameObject;
            oBall=other.transform;
            pBall = gO.transform;
            other.transform.parent = pBall;
            pBall.GetComponent<CapsuleCollider>().enabled = true;
            oBall.localPosition = Vector3.zero;
            oBall.localRotation=Quaternion.identity;
            targetSize = pBall.transform.localScale + new Vector3(9,9,9);


            hold = true;
            playerLocomotion.instance.lockk = true;
            grab = true;
            // rBall.isKinematic = false;
            // rBall.useGravity = true;
        }

    }

    public void Reset()
    {
        targetSize = pBall.transform.localScale - new Vector3(8, 8, 8);
        pBall.transform.localScale = targetSize;
    }
}
