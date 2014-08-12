﻿using UnityEngine;
using System.Collections;

public class SpeedBar: MonoBehaviour {

	public float speed = 10.0f;
	public float maxSpeed = 100.0f;
	private float initWidth;
	private float gaugeWidth;
	private float gaugeHeight;
	private float speedPercentage;

	public GameObject player;
	private PlayerControl playerControl;

	public Texture2D gaugeFg;
	public Texture2D gaugeBg;
	public Texture2D gaugeBgLeft;
	public Texture2D gaugeBgRight;

	public Color gaugeColor;

	void Awake () {
		
		//Player values
		playerControl = player.GetComponent<PlayerControl> ();
	}

	void OnGUI (){

		//UI is divided intro two GuiGroups.
		// 1 --> the moving gauge, made of one asset
		// 2 --> the gauge border, size is dynamic depending on assets. It's on top of the moving gauge


		gaugeWidth = (32 * playerControl.playerLevel) + gaugeBg.width + gaugeBgLeft.width + gaugeBgRight.width;
		gaugeHeight = gaugeBg.height;

		float convertedSpeed = ((speed/maxSpeed) * gaugeWidth);


		//first group
		if (player.name == "p1") {      //some hardcoded stuff to position the UI for each player, very dirty! 
			GUI.BeginGroup (new Rect (16, 16, gaugeWidth, gaugeHeight));
		} else {
			GUI.BeginGroup (new Rect (16, Screen.height / 2 + 16, gaugeWidth, gaugeHeight));
		}

			GUI.color = gaugeColor;   // set custom gauge color
			GUI.DrawTexture (new Rect(0,0, convertedSpeed,gaugeHeight),gaugeFg);	
			GUI.color = Color.white; // restore asset color

		//second group
		GUI.BeginGroup (new Rect ( 0,0, gaugeWidth, 32));
			
			GUI.DrawTexture (new Rect(0,0,gaugeBgLeft.width,gaugeHeight),gaugeBgLeft);	
			GUI.DrawTexture (new Rect(gaugeBgLeft.width,0, gaugeWidth-gaugeBgLeft.width-gaugeBgRight.width,gaugeHeight),gaugeBg, ScaleMode.StretchToFill);
			GUI.DrawTexture (new Rect(gaugeWidth - gaugeBgLeft.width,0,gaugeBgRight.width,gaugeHeight),gaugeBgRight);	

		GUI.EndGroup();
        
		GUI.EndGroup();
	}

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {


		speed = playerControl.speedH;
		maxSpeed = playerControl.maxSpeedH;
		speedPercentage = speed / maxSpeed;

		if (speedPercentage < 0) {
			speedPercentage = 0;
		}

		if (speedPercentage > 100) {
			speedPercentage = 100;
		}

		gaugeWidth = speedPercentage * initWidth;

	}
}