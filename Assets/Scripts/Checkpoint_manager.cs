using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Transform> checkPoint;
    private Transform curCheckPoint;
    [SerializeField] private GameObject Player;
    RaycastHit hit;
    private bool once;

    void Start()
    {
        curCheckPoint = checkPoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        landCheck();
        fallCheck();
    }

    void fallCheck()
    {
        if (Player.transform.position.y < playerLocomotion.instance.initialY - 6)
        {
            if (!once)
            {
                once = true;
                if (pushBall.instance.grab)
                {
                    Debug.Log("fallballwith");
                    pushBall.instance.pBall.GetComponent<CapsuleCollider>().enabled = false;
                    pushBall.instance.oBall.parent = null;
                    pushBall.instance.sphereCollider.enabled = true;
                    pushBall.instance.rBall.isKinematic = false;
                    pushBall.instance.rBall.useGravity = true;
                    playerLocomotion.instance.animator.SetLayerWeight(1, 0);
                    playerLocomotion.instance.lockk = false;
                    
                }
                StartCoroutine(wait());
                
            }
        }
    }
    void landCheck()
    {
        if (Physics.Raycast(playerLocomotion.instance.foot.position, Vector3.down, out hit ,.2f))
        {
            if(hit.transform.name== "Isle_01")
            {
                curCheckPoint = checkPoint[0];
            }
            else if(hit.transform.name== "Isle_02")
            {
                curCheckPoint = checkPoint[1];
            }
            else if (hit.transform.name == "Isle_03")
            {
                curCheckPoint = checkPoint[2];
            }
            else if (hit.transform.name == "Isle_04")
            {
                curCheckPoint = checkPoint[3];
            }
        }
    }

    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
        playerLocomotion.instance.animator.SetBool("OnGrnd", true);
        once = false;
        Player.transform.position = curCheckPoint.position;
        pushBall.instance.grab = false;
    }
}
