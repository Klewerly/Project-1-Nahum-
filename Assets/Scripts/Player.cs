using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    public Inventory inventory;
    public Slider slider;
    public GiveStatsToItems item;


    //public Items itemPickedUp;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = playerStats.health;


    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.health < 100)
        {
            PlayerHpSlider();

        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemCollider();
        }
    }

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }



    public void PlayerHpSlider()
    {

        slider.value = playerStats.health;


    }


    private void ItemCollider()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
        Collider closest = null;
        float oldDist = 2;
        foreach (Collider go in colliders)
        {
            if (go.gameObject.GetComponent<GiveStatsToItems>() != null)
            {
                float dist = Vector3.Distance(transform.position, go.transform.position);



                if (dist < oldDist)
                {
                    closest = go;
                    oldDist = dist;

                }


            }



        }
        if (closest == null)
        {
            return;
        }
        else
        {
            item = closest.gameObject.GetComponent<GiveStatsToItems>();
            inventory.AddItem(item.items);
            Destroy(item.gameObject);
        }


        


        
    }

    


}
