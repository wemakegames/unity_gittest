using UnityEngine;
using System.Collections;

public class player_mvt : MonoBehaviour {

	public Sprite spr1;
	public Sprite spr2;

	private float speed_h;
	private float speed_v;
	public float accel_h = 5.0f;
	public float accel_v = 5.0f;
	public float maxSpeed_h = 5.0f;
	public float maxSpeed_v = 5.0f;
	public float slowdown_h = 5.0f;
	public float slowdown_v = 5.0f;
	public float max_slowdown_v = 10.0f;

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
		CalcVForce();
		CalcHForce();
		rigidbody2D.AddForce(new Vector2(speed_h,speed_v));
	}



	void GetControls(){
		button1 = Input.GetButton(button1_name);
		button2 = Input.GetButton(button2_name);
	}

	void CalcVForce(){
		//check button
		if (button1 && button2) { 
			if (speed_v < maxSpeed_v) {
				speed_v += accel_v;
			}
		}

		if (speed_v > max_slowdown_v){
			speed_v -= slowdown_v;
		} else {
			speed_v = max_slowdown_v;
		}
	}


	void CalcHForce(){
		//check button

		if ( button1 && !button2 && button_next == 1 ) { 
			if  ( speed_h < maxSpeed_h ){
				speed_h += accel_h;
				GetComponent<SpriteRenderer>().sprite = spr1;
			}
			button_next = 2;
		}
		else if ( !button1 && button2 && button_next == 2 ) { 
			if  ( speed_h < maxSpeed_h ){
				speed_h += accel_h;
				GetComponent<SpriteRenderer>().sprite = spr2;
			}		
			button_next = 1;
		}
		
		if (speed_h > 0){
			speed_h -= slowdown_h ;
		} else {
			speed_h = 0;
		}
	}

	void ChangeSprite () {

	}
}

