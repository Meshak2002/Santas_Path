using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;
    public Transform target;
    [SerializeField]private float smoothTime;
    private Vector3 curVelocity=Vector3.zero;

    void Awake()
    {
        offset = transform.position-target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerFocus= offset+target.position;
        transform.position = Vector3.SmoothDamp(transform.position,playerFocus,ref curVelocity, smoothTime);
    }
}
