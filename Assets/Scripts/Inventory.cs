using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Items> inventory = new List<Items>();
    //[SerializeField] public Image icon;
    //private GiveStatsToItems itemIcon;
    //GiveStatsToItems item;



    public void AddItem(Items _item)
    {

        inventory.Add(_item);
       // icon.sprite = itemIcon.items.icon;
       // icon.enabled = true;

    }




}