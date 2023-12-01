using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocomotion : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float x;
    private float z;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    Vector3 input;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        gatherInput();
        setAnimation();
        Look();
    }

    void FixedUpdate()
    {
        Move();
    }
    void gatherInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        input = new Vector3(x, 0, z);
    }

    void Move()
    {
        rb.MovePosition(transform.position + transform.forward* input.normalized.magnitude * speed * Time.fixedDeltaTime);
    }
    void Look()
    {
        if (input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var inputIsomatrix = matrix.MultiplyPoint3x4(input);
            var reff = Quaternion.LookRotation(inputIsomatrix, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, reff, turnSpeed * Time.deltaTime);
        }
    }
    void setAnimation()
    {
        if (input.magnitude > 0.1f)
        {
            animator.SetFloat("Speed", speed /2);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}

