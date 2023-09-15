using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GiveStatsToItems : MonoBehaviour
{
    [SerializeField] public Items items;
	private Rigidbody rb;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		rb.mass = items.weight;
		rb.drag = 1;

	}


}

