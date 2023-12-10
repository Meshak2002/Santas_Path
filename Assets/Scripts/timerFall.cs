using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class timerFall : MonoBehaviour
{
    // Start is called before the first frame update
    private bool fall;
    private Vector3 initPos;
    public static timerFall instance;
    private float shakIntensity=0.05f;
    private bool bShake;
    private float shakeDuration=3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(waitt());
        }
    }

    void Start()
    {
        instance = this;
        initPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fall)
        {
            this.transform.Translate(Vector3.down * 10*Time.fixedDeltaTime);
        }

        if(bShake)
        {
            if(shakeDuration > 0)
            {
                shakeDuration -= Time.fixedDeltaTime;
                Vector3 shakPos = UnityEngine.Random.insideUnitSphere * shakIntensity;
                this.transform.position += shakPos;
            }
            else
            {
                shakeDuration = 0;
                bShake = false;
            }
        }
    }
    IEnumerator waitt()
    {
        yield return new WaitForSeconds(.6f);
        bShake = true;
        yield return new WaitForSeconds(.4f);
        bShake = false;
        shakeDuration = 0;
        fall = true;
        yield return new WaitForSeconds(2);
        Reset();
    }



    public void Reset()
    {
        fall = false;
        bShake = false;
        shakeDuration = 0;
        transform.position = initPos;
       
    }
}
