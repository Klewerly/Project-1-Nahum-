using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{ 
    None,
    Weapon,
    Potion,
    Shield,
}

public abstract class Items : ScriptableObject
{
    
    public ItemType type;
    public Sprite icon;
    public float weight;
    public float price;

}


public abstract class Weapons : Items
{
    public float damage;
    public float hands;
}

public abstract class Defense : Items
{
    public float defPoints;

}



public abstract class Potions : Items
{




}


public abstract class Ñurrency : Items
{



}