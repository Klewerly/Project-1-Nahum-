using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> inventory = new List<GameObject>();
    private Player player;
    

    public void AddItem(Items item)
    {
        item = player.itemPickedUp;
        inventory.Add(item);


    }


   // public List<Items> Inventory = new List<Items>() - создаем лист из всего что есть в Итемс и его детей. Пока не нужно.
}