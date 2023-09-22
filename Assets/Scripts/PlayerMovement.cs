using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent player;
    NavMeshAgent guardian;
    Player canBeat;
    public float speed;
    public float hitPointdist;
    public float playerTargetDist;
    public bool inFightZone;
    private Vector3 fightDistance;
    Animator animator;
    Npc enemyStats;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        guardian = GameObject.Find("Guardian").GetComponent<NavMeshAgent>();
        hitPointdist = 100;
        fightDistance = new Vector3(1, 0, -2);
        canBeat = GetComponent<Player>();
        enemyStats = GameObject.Find("Guardian").GetComponent<Npc>();






    }

    // Update is called once per frame
    void Update()
    {

        playerTargetDist = Vector3.Distance(guardian.transform.position, player.transform.position);

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                player.SetDestination(hit.point);

                hitPointdist = Vector3.Distance(guardian.transform.position, hit.point);



            }


        }

        if (hitPointdist < 2)
        {
            player.transform.LookAt(guardian.transform.position);
            
            if (playerTargetDist > 3)
            {

                //player.SetDestination(guardian.transform.position + fightDistance);
                player.SetDestination((transform.position - guardian.transform.position).normalized * 2 + guardian.transform.position);
                //guardian.transform.position.normalized * 1.3f + guardian.transform.position;
            }
            if (playerTargetDist < 3)
            {


                //player.SetDestination(guardian.transform.position + fightDistance);
                player.SetDestination((transform.position - guardian.transform.position).normalized * 2 + guardian.transform.position);


            }



        }

        if (playerTargetDist > 3)
        {
            inFightZone = false;
        }

        if (playerTargetDist < 3)
        {
            inFightZone = true;
        }

        if (enemyStats.npcStats.health > 0)
        {

            if (Input.GetMouseButtonDown(0))
            {

                if (inFightZone == true)
                {
                    if (hitPointdist < 2)
                    {
                        if (canBeat.armedNow == true)
                        {
                            animator.SetTrigger("Slash");
                        }
                    }
                }
            }
           
        }




        speed = player.velocity.magnitude;



    }

    public void AttackButton()
    {
        if (inFightZone == true)
        {
            animator.SetTrigger("Slash");
        }
    }


    

}
