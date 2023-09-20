using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



[Serializable]
public abstract class Stats
{

    public float health;
    public float mana;
    public float age;
    public float height;
    public float damage;
    public float defence;
}

[Serializable]
public class PlayerStats : Stats
{
    public float carryWeight;
    public float maxCarryWeight;
    public float repPoints;
    public float level;


}
[Serializable]
public class NpcStats : Stats
{

    public float angryLvl;


}

