using UnityEngine;
using System.Collections;

public class level_generator : MonoBehaviour {
	
	public GameObject tiles_0;
	public Sprite[] tiles;
	public int level_step = 0;
	int[][]map_data;
	
	// Use this for initialization
	void Start () {
		levels the_levels;
		the_levels = GetComponent<levels> ();

		tiles = Resources.LoadAll<Sprite> ("sprite");
		print (tiles.Length);

		//tiles_0.GetComponent<SpriteRenderer> ().sprite = tiles [0];
	
		//SpriteRenderer tile_sprite_renderer = tiles_0.GetComponent<SpriteRenderer> ();
		//tile_sprite_renderer.sprite = tiles[4];
		//tile_sprite_renderer.color = new Color (0f, 0f, 0f, 1f);
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



		for (z = 0; z < 15; z++) {
			the_step = z;
				for (y = 0; y < 12; y++) {
						for (x = 0; x < 96; x++) {
								if (map_data [0] [y * 96 + x] == 5) {
										Instantiate (tiles_0, new Vector3 ((1f * x) + 96f * the_step, (1f * -y) + 11f, 0), Quaternion.identity);
										

								} else if (map_data [0] [y * 96 + x] == 6) {
										
								}
						}
				}
		}
	}
}

