using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    NavMeshAgent guardian;
    [SerializeField] private GameObject[] patroolWayPoint;
    private int patroolPoints;







    // Start is called before the first frame update
    void Start()
    {

        guardian = GetComponent<NavMeshAgent>();



    }

    // Update is called once per frame
    void Update()
    {
            guardian.SetDestination(patroolWayPoint[patroolPoints].transform.position);

            float dist = Vector3.Distance(guardian.transform.position, patroolWayPoint[patroolPoints].transform.position);


            if (dist < 1)
            {
                patroolPoints++;
            }

            if (patroolWayPoint.Length == patroolPoints)
            {
                patroolPoints = 0;

            }

        return;

    }
    
   
       

    
}
