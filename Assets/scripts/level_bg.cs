using UnityEngine;
using System.Collections;

public class level_bg : MonoBehaviour {
	public GameObject bg_00;
	public GameObject bg_01;
	public GameObject bg_02;

	// Use this for initialization
	void Start () {


		for (var i = 0; i<12; i++) {
			var j = 8 * i;
			Instantiate(bg_00, new Vector3(j,0,3), Quaternion.identity);
			Instantiate(bg_01, new Vector3(j,0,6), Quaternion.identity);
			Instantiate(bg_02, new Vector3(j,0,9), Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
