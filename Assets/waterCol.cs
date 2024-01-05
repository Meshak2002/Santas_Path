using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCol : MonoBehaviour
{
    // Start is called before the first frame update
    public camerFollow cf;
    public Transform player;
    public GameObject splashFX;
    private CapsuleCollider cc;
    private playerLocomotion pl;
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
            StartCoroutine(waii());
            cc = other.gameObject.GetComponent<CapsuleCollider>();
            cc.enabled = false;
            pl = other.gameObject.GetComponent<playerLocomotion>();
            pl.enabled = false;
            cf.target = this.transform;
        }
    }
    IEnumerator waii()
    {
        yield return new WaitForSeconds(.2f);
        GameObject FX = Instantiate(splashFX, this.transform);
        yield return new WaitForSeconds(2f);
        cc.enabled = true;
        pl.enabled = true;
        cf.target = player;
        pl.Revive();
    }
}
