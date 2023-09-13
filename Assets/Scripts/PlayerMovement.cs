using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent player;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

        player = GetComponent<NavMeshAgent>();
        







    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                player.SetDestination(hit.point);
                
            }


        }

        speed = player.velocity.magnitude;



    }
}
