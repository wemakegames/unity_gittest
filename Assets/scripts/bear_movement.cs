using UnityEngine;
using System.Collections;

public class bear_movement : MonoBehaviour {

	
	public float speed_h;
	public float speed_v;
	public float accel_h = 5.0f;
	public float accel_v = 5.0f;
	public float maxSpeed_h = 5.0f;
	public float maxSpeed_v = 5.0f;
	public float slowdown_h = 5.0f;
	public float slowdown_v = 5.0f;

	private float button1;
	private float button2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetControls();
		ApplyForces();

		Debug.Log("B1  " + button1);

	}



	void GetControls(){
		/*speed_h = Input.GetAxis("Horizontal") * 5;
		speed_v = Input.GetAxis("Vertical") * 5;*/
		button1 = Input.GetAxis("Fire1");
		button2 = Input.GetAxis("Fire2");

	}

	void ApplyForces(){

		if (button1 > 0.5) { 
			if  (speed_h < maxSpeed_h){
				speed_h += accel_h;
			}
			
			if (speed_v < maxSpeed_v) {
				speed_v += accel_v;	
			}		
		}

		if (speed_v >= maxSpeed_v) {
			speed_v = 0;
		}

		//DECREASE
		if ((speed_h > 0) && (speed_h < slowdown_h)){
			speed_h = 0;

		}else if ((speed_h > 0) && (speed_h > slowdown_h)){
			speed_h -= slowdown_h;
		}

		speed_v -= slowdown_v;


		rigidbody2D.AddForce(new Vector2(speed_h,speed_v));
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

