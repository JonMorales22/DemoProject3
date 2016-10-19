﻿using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	public GameObject coinGB;
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag ("Player"))
			Debug.Log ("Player hit coin");
			Destroy (coinGB);
	}
}