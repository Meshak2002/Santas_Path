using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] offObjects;
    public GameObject player, portal,checkPoint;
    private bool pull;
    Rigidbody rg;
    Camera cam;
    public float pullStrength;
    public Transform cameraPivot;
    void Start()
    {
        /*foreach (var obj in offObjects)
        {
            obj.SetActive(false);
        }*/
        GameObject t = Instantiate(portal, player.transform.position,Quaternion.Euler(-90,0,0));
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y+.2f, player.transform.position.z);
        t.transform.position = pos;
        player.GetComponent<playerLocomotion>().enabled = false;
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Animator>().SetTrigger("Port");

        rg = player.GetComponent<Rigidbody>();
        checkPoint.SetActive(false);
        cam = cameraPivot.GetChild(0).GetComponent<Camera>();
        cameraPivot.GetComponent<camerFollow>().enabled = false;
        cameraPivot.transform.position=t.transform.position;
        rg.useGravity = false;
        pull = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(pull)
        {
            rg.AddForce(Vector3.down*pullStrength, ForceMode.Acceleration);
            if (cam.orthographicSize > 0)
            {
                cam.orthographicSize -= Time.deltaTime;
            }
            else
            {
                pull = false;
                transform.GetComponent<AudioSource>().Play();
                SceneManager.LoadScene(1);
            }
        }
    }
}
