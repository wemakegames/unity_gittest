using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject gameManager;
	private Component[] ps_array;
	public GameObject[] players;


	// Use this for initialization
	void Start () {
		gameManager = gameObject;
		players = GameObject.FindGameObjectsWithTag ("Player");

	}



	public IEnumerator Wait(float duration) {
		for (float timer = 0; timer < duration; timer += Time.deltaTime){
			yield return 0;
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
