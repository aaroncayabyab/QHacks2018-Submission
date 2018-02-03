using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerController : MonoBehaviour {

	public float speed = 6f;
	Vector3 movement;
	Rigidbody playerRigidbody;
	Animator anim;
	PlayerController instance;
	void Awake() 
	{
		if (instance == null) {
			instance = this;
		}
		playerRigidbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = CnInputManager.GetAxis ("MoveX");
		float v = CnInputManager.GetAxis ("MoveY");

		float h2 = CnInputManager.GetAxis ("AimX");
		float v2 = CnInputManager.GetAxis ("AimY");

		Move (-h,-v);
		Turning (-h2, -v2);
		Animating (-h, -v);


	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(float h2, float v2)
	{
		Vector3 playerDirection = new Vector3 (h2, 0f, v2);

		Quaternion newRotation = Quaternion.LookRotation (playerDirection+transform.forward);
		playerRigidbody.MoveRotation (newRotation);
	}

	void Animating(float h, float v)
	{
		bool running = h != 0f || v != 0f;
		anim.SetBool ("isRunning", running); 
	}
}
