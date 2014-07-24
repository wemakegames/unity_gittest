using UnityEngine;
using System.Collections;

public class camera_mvt : MonoBehaviour {

	private Transform myTarget;
	private GameObject p1;
	private GameObject p2;

	public float camSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find("player1");
		p2 = GameObject.Find("player2");
	}
	
	// Update is called once per frame

	void FixedUpdate () {

		if (p1.transform.localPosition.x > p2.transform.localPosition.x) {
			myTarget =	p1.transform;
		}else
		{
			myTarget = p2.transform;
		}

		//temp variable to store local position
		Vector3 temp = transform.localPosition;
		temp.x = Mathf.Lerp(transform.localPosition.x, myTarget.transform.localPosition.x, Time.deltaTime * camSpeed);
		transform.localPosition = temp;

	}
}
