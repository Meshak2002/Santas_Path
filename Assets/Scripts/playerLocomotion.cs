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
    public float gravity = 9.81f;
    public float jumpForce = 10f;

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
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
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

    bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        float rayDistance = 1f; // Adjust this based on your character's size
        
        if (Physics.Raycast(ray, rayDistance))
        {
            Debug.Log("GT");
            return true; // Player is grounded
        }
        Debug.Log("GF");
        return false; // Player is not grounded
    }

    void Jump()
    {
        /*if (IsGrounded())
        {*/
            Debug.Log("j");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}
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

