using UnityEngine;
using System.Collections;

public class menu_manager : MonoBehaviour {
	
	private bool button1;
	private bool button2;
	private bool button3;
	private bool button4;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckControls();
	}
	
	void CheckControls(){
		button1 = Input.GetButton("Fire1");
		button2 = Input.GetButton("Fire2");
		button3 = Input.GetButton("Fire3");
		button4 = Input.GetButton("Fire4");
		
		if (button1 || button2 || button3 || button4) {
			Application.LoadLevel("game");
		}
	}
}
