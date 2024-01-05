using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Oplayer, dPlayer,gb1,gb2,cam,chkpoint,fndGft;
    public PlayableDirector pd;
    private bool once;
    public float duration;

    private void Start()
    {
        StartCoroutine(waitTillcutSCene());
    }

    IEnumerator waitTillcutSCene()
    {
        yield return new WaitForSeconds(4.5f);
        Oplayer.SetActive(true);
        chkpoint.SetActive(true);
        Destroy(dPlayer.gameObject);
        Destroy(gb1);
        Destroy(gb2);
        Oplayer.GetComponent<Animator>().SetBool("OnGrnd", true);
        cam.transform.GetComponent<camerFollow>().enabled = true;
        fndGft.SetActive(true);
    }

}
