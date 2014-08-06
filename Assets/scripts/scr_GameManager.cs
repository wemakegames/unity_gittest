using UnityEngine;
using System.Collections;

public class scr_GameManager : MonoBehaviour {
	public static GameObject gameManager;

	// Use this for initialization
	void Start () {
		gameManager = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public ParticleSystem GetSystem (GameObject obj,string systemName){
		Component[] children = obj.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem childParticleSystem in children) {
			if (childParticleSystem.name == systemName) {
				return childParticleSystem;
			}
		}
		return null;
	}
}
