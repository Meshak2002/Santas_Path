using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("iceBall"))
        {
            if (pushBall.instance.got)
            {
                pushBall.instance.pBall.GetComponent<CapsuleCollider>().enabled = false;
                pushBall.instance.oBall.parent = null;
                pushBall.instance.sphereCollider.enabled = true;
                pushBall.instance.rBall.isKinematic = false;
                pushBall.instance.rBall.useGravity = true;
                playerLocomotion.instance.animator.SetLayerWeight(1, 0);
                playerLocomotion.instance.lockk = false;
                // Destroy(this.gameObject);
               // Debug.Log("Stop");
            }
            
        }
    }
}
