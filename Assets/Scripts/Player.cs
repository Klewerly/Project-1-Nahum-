using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerStats playerStats;
    public Inventory inventory;
    public Slider slider;
    public GiveStatsToItems item;
    [SerializeField] public GameObject inventoryPanel;
    NavMeshAgent playeNavMesh;
    private MeshRenderer axeModelHand;
    private MeshRenderer swordModelHand;
    private MeshRenderer axeModelHolder;
    private MeshRenderer swordModelHolder;
    Npc enemyStats;



    AnimationController animation;
    public bool armedNow;







    //public Items itemPickedUp;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = playerStats.health;
        animation = GetComponent<AnimationController>();
        playeNavMesh = GetComponent<NavMeshAgent>();
        axeModelHolder = GameObject.Find("Model_Axe_Holder").GetComponent<MeshRenderer>();
        swordModelHolder = GameObject.Find("Model_Sword_Holder").GetComponent<MeshRenderer>();
        axeModelHand = GameObject.Find("Model_Axe_Hand").GetComponent<MeshRenderer>();
        swordModelHand = GameObject.Find("Model_Sword_Hand").GetComponent<MeshRenderer>();
        enemyStats = GameObject.Find("Guardian").GetComponent<Npc>();


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

        if (Input.GetKeyDown(KeyCode.I))
        {
            playeNavMesh.SetDestination(playeNavMesh.transform.position);
            inventoryCloseAndOpen();
            if (inventoryPanel.active == true)
            {
                playeNavMesh.speed = 0;
            }
            if (inventoryPanel.active == false)
            {
                playeNavMesh.speed = 3.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {

            if (playerStats.damage > 0)
            {
                armedNow = !armedNow;


                if (armedNow == true)
                {


                    if (axeModelHolder.enabled == true)
                    {
                        animation.TakeWeapon();
                        axeModelHolder.enabled = false;
                        axeModelHand.enabled = true;
                    }

                    if (swordModelHolder.enabled == true)
                    {
                        animation.TakeWeapon();
                        swordModelHolder.enabled = false;
                        swordModelHand.enabled = true;
                    }


                }

                else
                {


                    if (axeModelHand.enabled == true)
                    {
                        animation.PutAwayWeapon();
                        StartCoroutine(AxeModelsOff(1));

                    }

                    if (swordModelHand.enabled == true)
                    {
                        animation.PutAwayWeapon();
                        StartCoroutine(SwordModelsOff(1));

                    }


                }
            }



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

    public void inventoryCloseAndOpen()
    {

        inventoryPanel.active = !inventoryPanel.active;

    }


    private IEnumerator SwordModelsOff(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        swordModelHand.enabled = false;
        swordModelHolder.enabled = true;
    }


    private IEnumerator AxeModelsOff(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        axeModelHand.enabled = false;
        axeModelHolder.enabled = true;
    }


    public void DealDamage()
    {
        enemyStats.npcStats.health = enemyStats.npcStats.health - playerStats.damage;

    }


}
    
