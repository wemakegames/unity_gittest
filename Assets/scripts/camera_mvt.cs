using UnityEngine;
using System.Collections;

public class camera_mvt : MonoBehaviour {

	public Transform myTarget;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target_position = myTarget.localPosition;
		target_position.x = myTarget.transform.position.x;
		target_position.y = 0;
		target_position.z = myTarget.transform.position.z - 10;

		transform.localPosition = target_position;
	}
}
