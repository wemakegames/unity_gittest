using UnityEngine;
using System.Collections;



public class player_death : MonoBehaviour {

	public GameObject mark;
	//public GameObject part_gibs;
	public GameObject part_blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mark && (transform.position.x > mark.transform.position.x)) {
			kill_player();


		}
	}

	void kill_player () {
		this.renderer.enabled = false;
		ParticleSystem[] part_gibs = GetComponentsInChildren<ParticleSystem>();

		for (int i=0; i < part_gibs.Length; i++){
			switch (part_gibs[i].name){
				case "particles_blood":
				part_gibs[i].Play();
				break;

				case "particles_death":
				part_gibs[i].Play();
				break;

				case "particles_rainbow":
				part_gibs[i].Stop();
				break;
			}
		}

		//part_blood.particleSystem.Play();
			//= transform.Find ("particles_death").GetComponent<ParticleSystem> ().particleEmitter.emit = true;
		DestroyObject(mark);
	}
}


