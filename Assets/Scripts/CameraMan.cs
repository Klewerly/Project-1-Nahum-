using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    public GameObject player;
    public float rotateSpeed = 1f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = new Vector3(transform.position.x + -30, transform.position.y + 2, transform.position.z + -20);
        offset = new Vector3(5, 7, -5);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);

        if (Input.GetKey(KeyCode.E))
        {
            offset = Quaternion.AngleAxis(rotateSpeed, Vector3.up) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            offset = Quaternion.AngleAxis(rotateSpeed, Vector3.down) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }

    }
}
