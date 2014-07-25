using UnityEngine;
using System.Collections;

public class menu_manager : MonoBehaviour {
	
	private bool button1;
	private bool button2;
	
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
		
		if (button1 || button2 ) {
			Application.LoadLevel("game");
		}
	}
}
