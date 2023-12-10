using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocomotion : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    private Rigidbody rb;
    private float x;
    private float z;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [HideInInspector] public Vector3 input;
    public float gravity = 9.81f;
    public float jumpForce = 10f;
    [HideInInspector] public float initialY;
    public Transform foot;
    public static playerLocomotion instance;
    [HideInInspector] public bool lockk;

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        initialY=transform.position.y;
    }
    private void Update()
    {
        gatherInput();
        setAnimation();
        Look();
        if (lockk== false) {
                if (IsGrounded() && Input.GetButtonDown("Jump"))
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree") || animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
                    {
                        Jump();
                    }
                }
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
        Vector3 pos = foot.position;
       // Debug.Log("GT");
        Ray ray = new Ray(pos, Vector3.down);
        float rayDistance = .6f;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, rayDistance))
        {
            animator.SetBool("OnGrnd", true);
            return true; // Player is grounded
        }
        animator.SetBool("OnGrnd", false);
        floorCheck();
        return false; // Player is not grounded
    }

    void Jump()
    {
        /*if (IsGrounded())
        {*/
        animator.SetTrigger("Jump");
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

    void floorCheck()
    {
        if (transform.position.y < initialY-6 )
        {
            animator.SetBool("OnGrnd", false);
        }
    }
}

