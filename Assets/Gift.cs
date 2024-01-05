using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public TMP_Text text;
    public GameObject FX;
    public GameObject Target,portal;
    GameObject g;
    bool once;

    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!once)
            {
                once = true;
                transform.GetComponent<AudioSource>().Play();
                g = Instantiate(FX, this.transform.position, Quaternion.Euler(-90, 0, 0));
                int count = int.Parse(text.text) + 1;
                text.text = count.ToString();
                if(portal != null)
                {
                    portal.SetActive(true);
                }
                StartCoroutine(destroyWai(g.transform));
            }
        }
    }

    IEnumerator destroyWai(Transform g)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2);
        if(Target != null )
        {
            Target.SetActive(true);
        }
        Destroy(g.gameObject);
        Destroy(this.gameObject);
    }
    
}
