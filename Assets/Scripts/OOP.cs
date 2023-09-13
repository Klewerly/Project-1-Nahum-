using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OOP : MonoBehaviour
{

    private Food food;
    private Meat chimpken;
    private Pork pork;
    private Vector3 position;

    private Food[] foods = new Food[3];

    private void Start()
    {
        //1. Используй MonoBehaviour только если это тебе необходимо.
        

    }


    private void EatAll()
    {
        foods[0].Eat();
        foods[1].Eat();
        foods[2].Eat();
        foods[1].Create();
    }
}


[Serializable]
public abstract class Food
{
    public float Weight;
    public float Colories;

    private bool isEaten = false;


    public virtual void Eat()
    {
        isEaten = true;
    }


    public abstract void Create();
}

public abstract class Meat : Food
{
    public float SpeedBoost;
    public override void Eat()
    {
        base.Eat();
        Debug.Log("Я НЕ ПРОСТО СЬЕЛ, А СВ/ИННИНИА");
    }
    
    
}

[Serializable]
public class Pork : Meat
{
    public string name;
    public override void Eat()
    {
        Debug.Log("Я НЕ ПРОСТО СЬЕЛ, А СВ/ИННИНИА");
    }

    public override void Create()
    {
    }
}