using UnityEngine;
using System.Collections;

public class camera_splitscreen : MonoBehaviour {

	public GameObject myTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	
	void FixedUpdate () {
		
		Vector3 temp_coord = transform.localPosition;
		temp_coord.x = myTarget.transform.localPosition.x;
		transform.localPosition = temp_coord;
		
	}
}
