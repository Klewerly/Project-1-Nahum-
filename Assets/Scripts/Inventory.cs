using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Items> inventory = new List<Items>();
    [SerializeField] public InventorySlot[] inventorySlots;
    [SerializeField] public GameObject[] itemModel;
    private InventorySlot icon;
    private InventorySlot button;
    private InventorySlot itemInSlot;
    [SerializeField] public InventoryUI slotsParent;





    public void Start()
	{

        icon = GetComponent<InventorySlot>();
        button = GetComponent<InventorySlot>();
        itemInSlot = GetComponent<InventorySlot>();
        inventorySlots = slotsParent.slotsParent.GetComponentsInChildren<InventorySlot>();
        
    }


	public void AddItem(Items _item)
    {

        inventory.Add(_item);

        

        for (int i = 0; i < inventorySlots.Length; i++)
        {

            if (i < inventory.Count)
            {
                inventorySlots[i].itemInSlot = inventory[i];
                inventorySlots[i].icon.sprite = inventory[i].icon;
                inventorySlots[i].icon.enabled = true;


            }

        }



    }

    


    


    



}

