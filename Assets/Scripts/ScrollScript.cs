﻿using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	public float speed;
	public int smoothing;
	public GameObject[] background;

	private float[] parallaxScales;
	private Renderer[] render;

	public Rigidbody2D playerRB;
	// Use this for initialization
	void Start () {
		//background = GetComponentsInChildren<GameObject> ();
		parallaxScales = new float[background.Length];
		render = new Renderer[background.Length];

		for (int i = 0; i < background.Length; i++) {
			parallaxScales [i] = background [i].transform.localPosition.z * 1;
			render [i] = background [i].GetComponent<Renderer> ();
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		
		for (int i = 0; i < background.Length; i++) {
			float xVal = (playerRB.velocity.x * parallaxScales [i]) / smoothing;
			Debug.Log ("xVal[" + i + "] = " + xVal);
			float yVal = ((playerRB.velocity.y/2) * parallaxScales [i]) / smoothing;
			Vector2 offset = new Vector2 (xVal,yVal);
			render[i].material.mainTextureOffset += offset;
		}
		//Vector2 offset = new Vector2 ((playerRB.velocity.x/smoothing),0);
		//Debug.Log ("Offset= "+playerRB.velocity.x / smoothing);
		//GetComponent<Renderer> ().material.mainTextureOffset += offset;
	}
}
