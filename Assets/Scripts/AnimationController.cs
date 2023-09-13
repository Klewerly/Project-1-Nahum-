using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent speed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (speed.velocity.magnitude > 0)
        {
            animator.SetBool("IsRunning", true);
            animator.Play("Running");

        }

        else
        {
            animator.SetBool("IsRunning", false);
            animator.Play("Breathing Idle");

        }

        return;
    }
}
