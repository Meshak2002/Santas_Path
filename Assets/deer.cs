using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deer : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public int index;

    void Start()
    {
        animator=GetComponent<Animator>();
        switch (index)
        {
            case 0:
                animator.Play("DDrink", 0);
                break;
            case 1:
                animator.Play("sadsa", 0);
                break;
            case 2:
                animator.Play("DSeat Idle", 0);
                break;
            case 3:
                animator.Play("DSleep Idle", 0);
                break;
            case 4:
                animator.Play("DWalk", 0);
                break;
            default:
                animator.Play("DSleep Idle", 0);
                break;
        }
        
        
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
