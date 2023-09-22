using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Npc : MonoBehaviour
{

    [SerializeField]public NpcStats npcStats;
    PlayerMovement player;
    AiController aiController;
    NavMeshAgent guardian;
    Animator animator;
    public Slider slider;
    public Canvas sliderCanvas;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        aiController = GetComponent<AiController>();
        guardian = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if(npcStats.health > 1)
        {

            
            if (player.inFightZone == true)
            {
                guardian.speed = 0;
                aiController.enabled = false;
                guardian.transform.LookAt(player.transform.position);
                animator.SetBool("Dance", true);
            }
            else
            {
                guardian.speed = 3.5f;
                aiController.enabled = true;
                animator.SetBool("Dance", false);
            }

        }

        if (npcStats.health < 100)
        {
            
            NpcHpSlider();
            if (npcStats.health > 1)
            {
                sliderCanvas.enabled = true;
            }
        }

        if (npcStats.health <= 0)
        {
            guardian.speed = 0;
            sliderCanvas.enabled = false;
            animator.SetTrigger("Death");
            Destroy(rb);
            aiController.enabled = false;

        }


    }

    public void NpcHpSlider()
    {

        slider.value = npcStats.health;


    }


    

}
