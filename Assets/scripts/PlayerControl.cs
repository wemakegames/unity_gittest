using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Sprite spr1;
	public Sprite spr2;
	private bool secondSprite = false;

	////////////
	/// Movement
	////////////

	private float speedH;
	public float maxSpeedH = 6.0f;
	public float accelH = 0.25f;
	public float decelH = 0.05f;

	private float speedV;
	public float maxSpeedV = 3.5f;
	public float accelV = 0.5f;
	public float decelV = 0.25f;
	public float maxFallSpeed = 5f;

	private Vector2 amountToMove;

	private bool grounded = false;
	private bool hitCeiling = false;
	private bool hitWall = false;

	private Transform groundCheck;
	private Transform ceilingCheck;
	private Transform wallCheck;

	////////////
	/// Controls
	////////////

	private bool button1;
	private bool button2;
	private bool button_next = false;
	
	public string button1_name;
	public string button2_name;


	// Use this for initialization

	void Start () {
		groundCheck = transform.Find ("groundCheck");
		ceilingCheck = transform.Find ("ceilingCheck");
		wallCheck = transform.Find ("wallCheck");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		GetControls ();
		CalcHForce ();
		CalcVForce ();

		Move();
	}


	void GetControls(){
		button1 = Input.GetButton(button1_name);
		button2 = Input.GetButton(button2_name);
	}

	void CalcHForce(){
		//check button
		hitWall = Physics2D.Linecast(transform.position,wallCheck.position,1 << LayerMask.NameToLayer("Ground"));


		if (!hitWall) {
			if (( button1 && !button2 && button_next == false ) || (!button1 && button2 && button_next == true)) {
				//accellerate if not against wall
				 
				if  ( speedH < maxSpeedH ){
					speedH += accelH;
				} else {
					speedH = maxSpeedH;
				}
				button_next = !button_next;
				ChangeSprite();
			}

			//decellerate
			if (speedH > 0) {
				speedH -= decelH;
			} else {
				speedH = 0;
			}

		} else {
			//stop if next to wall
			speedH = 0;
		}
	}

	void CalcVForce(){

		grounded = Physics2D.Linecast(transform.position,groundCheck.position,1 << LayerMask.NameToLayer("Ground"));
		hitCeiling = Physics2D.Linecast(transform.position,ceilingCheck.position,1 << LayerMask.NameToLayer("Ground"));

		//Gravity
		if (!grounded) {
			if (speedV < -maxFallSpeed){
				speedV = -maxFallSpeed;
			} else {
				speedV -= decelV;
			}
		} else {
			speedV = 0;
		}

		//Goin up

		if (!hitCeiling){
			if (button1 && button2) { 
				if  ( speedV < maxSpeedV ){
					speedV += accelV;
				} 
				else {
					speedV = maxSpeedV;
				}
			}
		}
		else {
			speedH = 0;
		}

		speedV -= decelV;
	}


	void Move(){
		amountToMove = new Vector2 ( speedH, speedV );
		transform.Translate( amountToMove * Time.deltaTime );
	}

	void ChangeSprite() {
		switch (secondSprite) 
		{
			case false:
			GetComponent<SpriteRenderer>().sprite = spr1;
			break;

			case true:
			GetComponent<SpriteRenderer>().sprite = spr2;
			break;
		}

		secondSprite = !secondSprite;
	}



}
