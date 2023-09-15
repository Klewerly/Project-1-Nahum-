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
    public GameObject itemPickedUp;


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
    }



    public void PlayerHpSlider()
    {

        slider.value = playerStats.health;


    }
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GiveStatsToItems>();

        if (item)
        {

            itemPickedUp = other.gameObject;
            inventory.AddItem(item.items);

        }
    }



}
