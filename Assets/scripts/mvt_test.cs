using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]

public class mvt_test : MonoBehaviour {


	public float maxSpeedH = 5.0f;
	private float speedH;
	public float accelH = 1.0f;
	public float decelH = 0.5f;


	public float maxSpeedV = 5.0f;
	private float speedV;
	public float accelV = 1.0f;
	public float decelV = 0.5f;

	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;



	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetControls ();
		CalcHForce ();
		CalcVForce ();
		amountToMove = new Vector2 (speedH, speedV);
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}


	void GetControls(){

	}

	void CalcHForce(){
		//check button
		
		if ( Input.GetButton("Jump") ) { 
			if  ( speedH < maxSpeedH ){
				speedH += accelH;
			} else {
				speedH = maxSpeedH;
			}
		}
		if (speedH > 0) {
				speedH -= decelH;
		} else {
			speedH = 0;
		}
	}



	void CalcVForce(){
		//check button
		
		if ( Input.GetButton("Jump") ) { 
			if  ( speedV < maxSpeedV ){
				speedV += accelV;
			} else {
				speedV = maxSpeedV;
			}
		}

		speedV -= decelV;
	}






}
