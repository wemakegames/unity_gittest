using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject gameManager;
	private Component[] ps_array;
	public float startTimer = 3.0f;
	private GameObject[] players;

	// Use this for initialization
	void Start () {
		gameManager = gameObject;

		players = GameObject.FindGameObjectsWithTag ("Player");
		StartCoroutine(StartSequence());   //launches startup coroutine	
	}

	IEnumerator StartSequence () { 
		//startup coroutine runs every frame until it's done (no need to go thorugh update() )
		for (float timer = startTimer; timer > 0; timer -= Time.deltaTime){
			yield return 0; //wait till next frame
		}		
		foreach ( GameObject player in players) {
			Debug.Log("START!!!");
			player.GetComponent<PlayerControl>().active = true;			
		}		
	}

	
	// Update is called once per frame
	void Update () {

	}

	public ParticleSystem GetSystem (GameObject obj,string systemName){
		ps_array = obj.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem childParticleSystem in ps_array) {
			if (childParticleSystem.name == systemName) {
				return childParticleSystem;
			}
		}
		return null;
	}
}
