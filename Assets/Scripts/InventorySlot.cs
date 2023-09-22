using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] public Image icon;
    [SerializeField] public Button button;
    [SerializeField] public Items itemInSlot;
    private Image image;
    private bool itemActive;
    private bool isDressed;
    private bool modelActive;
    private InventorySlot itemToDress;
    private Player playerStats;
    private MeshRenderer axeModel;
    private MeshRenderer swordModel;
    private MeshRenderer shieldModel;

    //private InventorySlot itemToDress;



    public void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<Player>();
        axeModel = GameObject.Find("Model_Axe_Holder").GetComponent<MeshRenderer>();
        swordModel = GameObject.Find("Model_Sword_Holder").GetComponent<MeshRenderer>();
        shieldModel = GameObject.Find("Model_Shield").GetComponent<MeshRenderer>();

    }


    public void ClearSlot()
    {

        itemInSlot = null;
        icon.sprite = null;
        icon.enabled = false;


    }

    public void ItemActiveIndicator()
    {
        if (playerStats.armedNow == false)
        {
            itemActive = !itemActive;

            if (itemActive == true)
            {
                image = GetComponentInChildren<Image>();
                image.enabled = true;

            }

            else
            {
                image.enabled = false;
            }
        }

    }
    public void DressItem()
    {
        if (playerStats.armedNow == false)
        {
        isDressed = !isDressed;

            if (isDressed == true)
            {


                if (itemInSlot is Weapons weapons)
                {
                    playerStats.playerStats.damage += weapons.damage;

                    if (weapons is Axe axe)
                    {
                        axeModel.enabled = true;






                    }

                    if (weapons is Sword sword)
                    {

                        swordModel.enabled = true;

                    }



                }

                if (itemInSlot is Defense shield)
                {
                    playerStats.playerStats.defence += shield.defPoints;
                    shieldModel.enabled = true;





                }


            }

            else
            {
                if (itemInSlot is Weapons weapons)
                {
                    playerStats.playerStats.damage -= weapons.damage;

                    if (weapons is Axe axe)
                    {
                        axeModel.enabled = false;


                    }

                    if (weapons is Sword sword)
                    {
                        swordModel.enabled = false;


                    }




                }

                if (itemInSlot is Defense shield)
                {
                    playerStats.playerStats.defence -= shield.defPoints;
                    shieldModel.enabled = false;



                }

            }

        }
    }
    
}