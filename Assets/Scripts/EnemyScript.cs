﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	[HideInInspector]
	public bool isFacingRight = true;
	[HideInInspector]
	public bool isJumping = false;
	[HideInInspector]
	public bool isGrounded = false;

	public float walkSpeed=7.0f;
	public float maxSpeed=14.0f;
	public float jumpForce = 750.0f; 


	public Transform groundCheck;
	public LayerMask groundLayers;

	public Animator anim;
	public AudioClip footstep;
	public AudioClip deathsound;


	private float groundCheckRadius = .2f;
	private AudioSource audiosource;
	private bool isDead = false;
	private Rigidbody2D player;
	private int move = 1;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		player.velocity = new Vector2 (move * walkSpeed, player.velocity.y);

		if((move>0.0f&&!isFacingRight) || (move<0.0&& isFacingRight)) {
			Flip();
		}
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x*-1;
		transform.localScale = playerScale;

	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.CompareTag ("Wall")) {
			Flip ();
			move *= -1;
		}
	}
}
