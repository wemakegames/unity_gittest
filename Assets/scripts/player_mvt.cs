﻿using UnityEngine;
using System.Collections;

public class player_mvt : MonoBehaviour {

	
	private float speed_h;
	private float speed_v;
	public float accel_h = 5.0f;
	public float accel_v = 5.0f;
	public float maxSpeed_h = 5.0f;
	public float maxSpeed_v = 5.0f;
	public float slowdown_h = 5.0f;
	public float gravity = 5.0f;
	public float gravity_max = -1.0f;

	private bool button1;
	private bool button2;
	private int button_next = 1;

	public string button1_name;
	public string button2_name;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetControls();
		CalcForces();
		rigidbody2D.AddForce(new Vector2(speed_h,speed_v));
	}



	void GetControls(){
		button1 = Input.GetButton(button1_name);
		button2 = Input.GetButton(button2_name);
	}

	void CalcForces(){
		//check button
		if (button1 && button2) { 
			if  (speed_h < maxSpeed_h){
				//speed_h += accel_h/4;
			}
			if (speed_v < maxSpeed_v) {
				speed_v += accel_v;	
			}
		}
		else if (button1 && button_next == 1) { 
			if  (speed_h < maxSpeed_h){
				speed_h += accel_h;
			}
			if (speed_v < maxSpeed_v) {
				speed_v += accel_v;	
			}
			button_next = 2;

		}
		else if (button2 && button_next == 2) { 
			if  (speed_h < maxSpeed_h){
				speed_h += accel_h;
			}
			if (speed_v < maxSpeed_v) {
				speed_v += accel_v;	
			}		
			button_next = 1;
		}

		if (speed_v > gravity_max){
			speed_v -= gravity;
		}







		//DECREASE
		if ((speed_h > 0) && (speed_h < slowdown_h)){
			speed_h = 0;

		}else if ((speed_h > 0) && (speed_h >= slowdown_h)){
			speed_h -= slowdown_h;
		}


			




	}


	/*void Flip(){
		if (Input.GetAxis("Horizontal")< 0) {
			Vector3 theScale = transform.localScale;
			theScale.x = -1;
			transform.localScale = theScale;
		} else {
			Vector3 theScale = transform.localScale;
			theScale.x = +1;
			transform.localScale = theScale;
		}
	}*/



}
