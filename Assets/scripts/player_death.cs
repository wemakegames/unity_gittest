using UnityEngine;
using System.Collections;



public class player_death : MonoBehaviour {

	public GameObject mark;

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

		ParticleSystem myPart = scr_GameManager.gameManager.GetComponent<scr_GameManager>().GetSystem(gameObject, "particles_stars");
		myPart.Play();
		
		myPart = scr_GameManager.gameManager.GetComponent<scr_GameManager>().GetSystem(gameObject, "particles_blood");
		myPart.Play();

		myPart = scr_GameManager.gameManager.GetComponent<scr_GameManager>().GetSystem(gameObject, "particles_rainbow");
		myPart.Stop();
	
		DestroyObject(mark);
	}
}


