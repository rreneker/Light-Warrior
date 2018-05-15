using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum colour{red,blue,green};

public class movement : MonoBehaviour {

	public float speed = 5.0f;

	public float miny,maxy;

	public int health = 100;

	public int init_h = 100;

	public Text p_health;

	colour cur_color = colour.red;

	public float last_time_hspawn;

	public AudioSource shot;

	// Use this for initialization
	void Start () {
		float vertDim = Camera.main.orthographicSize;
		miny = -1 * vertDim + this.transform.localScale.y/2;
		maxy = vertDim - this.transform.localScale.y/2;
		this.GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		p_health.text = health.ToString ();
		/*if (Input.GetKey ("w") == true && this.transform.position.y < maxy) {
			Vector2 new_pos = this.transform.position;
			new_pos.y += speed * Time.deltaTime;
			this.transform.position = new_pos;

		} else if (Input.GetKey ("s") == true && this.transform.position.y > miny) {
			Vector2 new_pos = this.transform.position;
			new_pos.y -= speed * Time.deltaTime;
			this.transform.position = new_pos;
		}*/
		Vector3 mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (mouse_pos.y > maxy) {
			mouse_pos.y = maxy;
		} else if (mouse_pos.y < miny) {
			mouse_pos.y = miny;
		} 
		mouse_pos.x = this.transform.position.x;
		mouse_pos.z = 0;
		this.transform.position = mouse_pos;

		if (Input.GetKeyDown ("1")) {
			cur_color = colour.red;
		} else if (Input.GetKeyDown ("2")) {
			cur_color = colour.blue;
		} else if (Input.GetKeyDown ("3")) {
			cur_color = colour.green;
		}

		if (cur_color == colour.red) {
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
		} else if (cur_color == colour.blue) {
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.blue);
		} else if (cur_color == colour.green) {
			this.GetComponent<Renderer>().material.SetColor ("_Color", Color.green);
		}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			shot.Play();
			GameObject Bullet = (GameObject)Instantiate(Resources.Load("bullet"));
			Bullet.transform.position = this.transform.position;
			Bullet.name = "bullet";
			bullet stuff = Bullet.GetComponent("bullet") as bullet;
			stuff.color = this.cur_color;

		}

		if (health <= 0) {
			GameObject pers = GameObject.Find("peristant_info");
			GameObject cont = GameObject.Find("controller");
			persistance stuff = pers.GetComponent("persistance") as persistance;
			controller cont_stuff = cont.GetComponent("controller") as controller;
			stuff.score = cont_stuff.score;

			Application.LoadLevel("_gameover");
		}

		//Spawn health
		float curr_hchance = ((init_h - health) / init_h) * 0.1f + (last_time_hspawn / 90.0f);
		float rand_val = Random.Range (0.0f, 100.0f);
		if (rand_val <= curr_hchance) {
			GameObject h = (GameObject)Instantiate(Resources.Load("healthpack"));
			Vector3 spawn = new Vector3(0,0,0);
			float max_x = maxy*(16/9);
			spawn.y = Random.Range (miny,maxy);
			spawn.x = Random.Range(0.0f,max_x-2.0f);
			h.transform.position = spawn;
			last_time_hspawn = 0.0f;
		} else {
			last_time_hspawn += Time.deltaTime;
		}
	
	}
}
