using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Items : ScriptableObject
{

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