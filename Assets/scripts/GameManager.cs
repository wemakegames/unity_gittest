using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject gameManager;
	private Component[] ps_array;

	// Use this for initialization
	void Start () {
		gameManager = gameObject;
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
