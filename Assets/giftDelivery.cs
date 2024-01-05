using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class giftDelivery : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tg1, tg2, tg3;
    public GameObject Odeer,pFX,timeLine,player,dup,BGM;
    public Camera cam;
    Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null)
        {
            anim.SetBool("OnGrnd", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(getReady());
            anim=dup.GetComponent<Animator>();
        }
    }
    IEnumerator getReady()
    {
        pFX.SetActive(false);
        tg1.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(.2f);
        tg2.SetActive(true);
        yield return new WaitForSeconds(.2f);
        BGM.SetActive(false);
        tg3.SetActive(true);
        Odeer.SetActive(false);
        cam.orthographic = false;
        cam.transform.parent.GetComponent<camerFollow>().enabled = false;
        timeLine.SetActive(true);
    }
}
