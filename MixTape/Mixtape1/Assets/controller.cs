using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controller : MonoBehaviour {

	public int score = 0;
	public float time_between_spawn = 1.0f;
	public float curr_time = 2.0f;
	public float size;
	public float max_x;
	public int i = 0;
	public GameObject pers;
	public int wall_health = 5000;

	public Text w_health;
	public Text score_text;

	public AudioSource wHit;
	public AudioSource eHit;


	// Use this for initialization
	void Start () {
		size = Camera.main.orthographicSize;
		max_x = (size *16)/9;

	}
	
	// Update is called once per frame
	void Update () {
		w_health.text = wall_health.ToString ();
		score_text.text = score.ToString ();
		while(i < 5){
			if(curr_time >= time_between_spawn){
				GameObject Enemy = (GameObject)Instantiate(Resources.Load ("enemy"));
				Vector3 start_pos = new Vector3(max_x,0,0);
				size -= 1;
				start_pos.y = Random.Range (-1*size,size);
				Enemy.transform.position = start_pos;
				curr_time = 0.0f;
				i++;
			}else{
				curr_time += Time.deltaTime;
			}
		}

		if (wall_health <= 0) {

			persistance stuff = pers.GetComponent("persistance") as persistance;
			stuff.score = score;
			Application.LoadLevel("_gameover");
		}
	
	}
}
