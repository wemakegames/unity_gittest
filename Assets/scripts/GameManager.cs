using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject gameManager;
	private Component[] ps_array;
	public GameObject[] players;


	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		gameManager = gameObject;
	}



	public IEnumerator Wait(float duration) {
		for (float timer = 0; timer < duration; timer += Time.deltaTime){
			yield return 0;
		}
	}

	
	// Update is called once per frame
	void Update () {
		Cheat ();
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

	public void Cheat() {

		if ((players [0].transform.position.x - players [1].transform.position.x) > 10) {
			players[1].GetComponent<PlayerControl>().speedH += players[1].GetComponent<PlayerControl>().maxSpeedH;
		} else if ((players [1].transform.position.x - players [0].transform.position.x) > 10 ) {
			players[0].GetComponent<PlayerControl>().speedH += players[0].GetComponent<PlayerControl>().maxSpeedH;
		}
	}

}
