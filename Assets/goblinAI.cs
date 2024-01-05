using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class goblinAI : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent navAgent;
    private Animator animator;
    public GameObject player;
    public Transform waypointParent;
    [SerializeField ]private Transform[] waypoint;
    public LayerMask playerMask;
    private int checkPoint = 0;
    private float patrolSpeed = 2f, chaseSpeed = 3f;
    public float enemySight, attackRange;
    private bool isPlayerInSight, isPlayerinAttackRange;
    private bool bAttacked;

    private void Awake()
    {
        waypoint = waypointParent.GetComponentsInChildren<Transform>();
    }

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
     }

    // Update is called once per frame
    void Update()
    {
       
        if (isPlayerinAttackRange=Physics.CheckSphere(transform.position,attackRange,playerMask))
        {
            Attack();
        }
        else if (isPlayerInSight = Physics.CheckSphere(transform.position, enemySight, playerMask))
        {
            navAgent.speed = chaseSpeed;
            Chase();
        }
        else
        {
            navAgent.speed = patrolSpeed;
            Patrol();
        }
    }

    void Patrol()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetBool("Idle", false);
        if (checkPoint < waypoint.Length)
        {
            if (waypoint[checkPoint] != null)
            {
                navAgent.SetDestination(waypoint[checkPoint].position);
                if (Vector3.Distance(transform.position, waypoint[checkPoint].position) < .5f)
                {
                    checkPoint++;
                }
            }
        }
        else
        {
            checkPoint = 0;
        }
    }

    void Chase()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetBool("Idle", false);
        navAgent.SetDestination(player.transform.position);
    }

    void Attack()
    {
        if (!bAttacked)
        {
            navAgent.speed = chaseSpeed + 1;
            bAttacked = true;
            navAgent.SetDestination(player.transform.position);
            transform.LookAt(player.transform.position);
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetBool("Attack", true);

        transform.GetComponent<AudioSource>().Play();
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(1).IsName("Attack01"));
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length/2);

        Animator animP = player.transform.GetComponent<Animator>();
        animP.SetTrigger("Die");
        player.transform.GetComponent<playerLocomotion>().enabled = false;

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length / 2);
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", true);

        animator.SetLayerWeight(1, 0);
        player.transform.GetComponent<playerLocomotion>().enabled = true;
        player.transform.GetComponent<playerLocomotion>().Revive();
        yield return new WaitForSeconds(1f);
        bAttacked = false;

    }
}
