using UnityEngine;
using System.Collections;

public class StartUpSequence : MonoBehaviour {

	private GameManager gameManager;
	private string startTimer;

	public Font font;

	// Use this for initialization
	void Start () {
		gameManager = GetComponent<GameManager>();
		StartCoroutine(StartSequence());   //launches startup coroutine	
	}

	IEnumerator StartSequence () { 
		//startup coroutine runs every frame until it's done (no need to go thorugh update() )
		startTimer = "GET READY";
		yield return StartCoroutine(gameManager.Wait (1.0f));
		startTimer = "3";
		yield return StartCoroutine(gameManager.Wait (1.0f));
		startTimer = "2";
		yield return StartCoroutine(gameManager.Wait (1.0f));
		startTimer = "1";
		yield return StartCoroutine(gameManager.Wait (1.0f));
		startTimer = "GO";
		yield return StartCoroutine(gameManager.Wait (1.0f));

		foreach ( GameObject player in gameManager.players) {
			Debug.Log("START!!!");
			player.GetComponent<PlayerControl>().active = true;			
		}	

		this.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUIStyle startUpLabel = new GUIStyle (GUI.skin.label);
		startUpLabel.font = font;
		startUpLabel.fontSize = 100;
		startUpLabel.alignment = TextAnchor.MiddleCenter;
		startUpLabel.normal.textColor = Color.yellow;
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height/2), startTimer, startUpLabel);
		GUI.Label(new Rect(0, Screen.height/2, Screen.width, Screen.height/2), startTimer, startUpLabel);
	}
}
