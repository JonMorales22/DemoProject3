﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CatchScript : MonoBehaviour {
	public Transform player;
	//public GameObject playerGB;
	private PlayerStats stats;
	// Use this for initialization
	void Start () {
		stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Player")) {
			stats = c.gameObject.GetComponent<PlayerStats> ();
			if (PlayerPrefs.GetInt ("247127CurrentPlayerLives") >= 0)
			{
				PlayerPrefs.SetInt ("247127CurrentPlayerScore", stats.score);
				SceneManager.LoadScene (1);
			}
		} 
	}
}
