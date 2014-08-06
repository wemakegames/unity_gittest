using UnityEngine;
using System.Collections;

public class player_hearts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.tag == "heart") {
			ParticleSystem myPart = scr_GameManager.gameManager.GetComponent<scr_GameManager>().GetSystem(gameObject, "particles_stars");
			myPart.Play();
			Destroy(collision.gameObject);
		}
	}

}
