using UnityEngine;
using System.Collections;

public class level_generator : MonoBehaviour {
	public static int chunks = 15;
	public GameObject tiles_0;
	public Sprite[] tiles;
	public int level_step = 0;
	int[][]map_data;
	
	// Use this for initialization
	void Start () {
		levels the_levels;
		the_levels = GetComponent<levels> ();
		tiles = Resources.LoadAll<Sprite>("sprite/tiles");
		the_levels.Start ();
		map_data = the_levels.map_data_array;
		GenerateLevel (0);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			level_step++;
			//GenerateLevel(level_step);
			print(level_step);
		}
		
	}
	
	void GenerateLevel(int the_step){
		int x, y, z;

		for (z = 0; z < chunks; z++) 
		
		{	
		
			the_step = z;

			for (y = 0; y < 12; y++) {
				for (x = 0; x < 96; x++) {
					tiles_0.GetComponent<BoxCollider2D> ().enabled = true;
					if (map_data [z] [y * 96 + x] == 5) {
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [4];					
					} else if (map_data [z] [y * 96 + x] == 6) {
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [5];
							tiles_0.GetComponent<BoxCollider2D> ().enabled = false;
					} else if (map_data [z] [y * 96 + x] == 4) {
							tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [3];
					} else if (map_data [z] [y * 96 + x] == 2) {
						tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [1];
					} else if (map_data [z] [y * 96 + x] == 3) {
						tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [2];
					}else if (map_data [z] [y * 96 + x] == 7) {
						tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [6];
					}else if (map_data [z] [y * 96 + x] == 8) {
						tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [7];
					}

					if (map_data [z] [y * 96 + x] != 0){
						Instantiate (tiles_0, new Vector3 ((1f * x) + 96f * the_step, (1f * -y) + 11f, 0), Quaternion.identity);									
					}
				}
			}
		}
	}
}




