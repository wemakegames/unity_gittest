using UnityEngine;
using System.Collections;

public class PlayerHeartsGrab : MonoBehaviour {

	public int heartCount = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.tag == "heart") {

			//heartCount += 1;

			ParticleSystem myPart = scr_GameManager.gameManager.GetComponent<scr_GameManager>().GetSystem(gameObject, "particles_stars");
			myPart.Play();
			Destroy(collision.gameObject);

		}
	}

}
