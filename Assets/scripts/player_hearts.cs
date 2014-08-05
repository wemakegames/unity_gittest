using UnityEngine;
using System.Collections;

public class player_hearts : MonoBehaviour {

	 //Use this for initialization
	void onTriggerEnter2D(Collider2D coll) {
		//if (coll.gameObject.tag == "heart") {
			Debug.Log ("heart");
		//}		
	}
}
