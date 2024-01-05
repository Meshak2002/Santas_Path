using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerDisable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public int duration=3;

    void Start()
    {
        StartCoroutine(waitt());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*10*duration);
    }

    IEnumerator waitt()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
