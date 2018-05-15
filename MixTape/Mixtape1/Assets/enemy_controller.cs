using UnityEngine;
using System.Collections;

public enum enemy_ai{straight, moveToPlayer, sine, zigzag};

public class enemy_controller : MonoBehaviour {

	public float speed;
	public colour color;
	public GameObject cont;
	public GameObject player;
	public enemy_ai ai;
	public float size;
	public float max_x;
	public float sine_amp;
	public bool zz_up_down = false;
	public float lifetime = 0.0f;

	public GameObject wHit;
	public GameObject eHit;
	public GameObject pHit;


	// Use this for initialization
	void Start () {
		cont = GameObject.Find ("controller");
		player = GameObject.Find ("Player");
		pHit = GameObject.Find ("pHit");
		wHit = GameObject.Find ("wHit");
		eHit = GameObject.Find ("eHit");
		size = Camera.main.orthographicSize;
		max_x = (size *16)/9;
		int rand_color = Random.Range (0, 3);
		if (rand_color == 0) {
			color = colour.red;
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
		} else if (rand_color == 1) {
			color = colour.blue;
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.blue);
		} else if (rand_color == 2) {
			color = colour.green;
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
		}

		int rand_ai = Random.Range (0, 3);
		if (rand_ai == 0) {//Straight AI
			ai = enemy_ai.straight;
		} else if (rand_ai == 1) {//Zig Zag AI
			ai = enemy_ai.zigzag;
			int rand_dir = Random.Range (0, 2);
			if (rand_dir == 0) {
				zz_up_down = false;
			} else {
				zz_up_down = true;
			}
		} else if (rand_ai == 2) {//Move to Player AI
			ai = enemy_ai.moveToPlayer;
		} else if (rand_ai == 3) {//sine AI
			Vector3 curr_poss = this.transform.position;
			sine_amp = size - Mathf.Abs(curr_poss.y);
			ai = enemy_ai.sine;
			print("sine created");
		}


		speed = Random.Range (4.0f, 8.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (ai == enemy_ai.straight) {//straight
			Vector3 curr_pos = this.transform.position;
			curr_pos.x -= speed * Time.deltaTime;
			this.transform.position = curr_pos;
		} else if (ai == enemy_ai.zigzag) {//zig zag
			float comp_speed = speed;
			Vector3 curr_pos = this.transform.position;
			if (zz_up_down == true) {
				curr_pos.x -= comp_speed * Time.deltaTime;
				curr_pos.y += comp_speed * Time.deltaTime;
			} else {
				curr_pos.x -= comp_speed * Time.deltaTime;
				curr_pos.y -= comp_speed * Time.deltaTime;
			}
			if (curr_pos.y >= (size - 1)) {
				zz_up_down = false;
			}
			if (curr_pos.y <= (-1 * (size - 1))) {
				zz_up_down = true;
			}
			this.transform.position = curr_pos;
		} else if (ai == enemy_ai.moveToPlayer) {//move to player
			Vector3 curr_pos = this.transform.position;
			if (player.transform.position.y > curr_pos.y) {
				curr_pos.y += speed * Time.deltaTime;
			} else if (player.transform.position.y < curr_pos.y) {
				curr_pos.y -= speed * Time.deltaTime;
			}
			curr_pos.x -= speed * Time.deltaTime;
			this.transform.position = curr_pos;
		} else if (ai == enemy_ai.sine) {//sine
			Vector3 curr_poss = this.transform.position;
			curr_poss.x -= speed*Time.deltaTime;
			curr_poss.y += Mathf.Sin(lifetime)*Time.deltaTime;
			lifetime += Time.deltaTime;
			this.transform.position = curr_poss;


		}

		if (this.transform.position.x <= (-1 * max_x)) {
			wHit.GetComponent<AudioSource>().Play ();
			Destroy(this.gameObject);
			controller shit = cont.GetComponent("controller") as controller;
			shit.wall_health -= 200;
			gen_next ();
		}
	
	}

	void OnTriggerEnter(Collider other){

		string name = other.name;
		GameObject coll = other.gameObject;

		if (name == "Player") {
			pHit.GetComponent<AudioSource>().Play();
			movement stuff = coll.GetComponent("movement") as movement;
			stuff.health -= 25;
			Destroy(this.gameObject);
			gen_next();

		} else if (name == "bullet") {
			bullet stuff = coll.GetComponent("bullet") as bullet;

			if(stuff.color == this.color){
				eHit.GetComponent<AudioSource>().Play();
				Destroy(this.gameObject);
				gen_next();
				controller shit = cont.GetComponent("controller") as controller;
				shit.score += 250;
			}

			Destroy(coll.gameObject);

		}


	}

	void gen_next(){
		GameObject newEnemy = (GameObject)Instantiate(Resources.Load("enemy"));
		Vector3 start_pos = new Vector3(max_x,0,0);
		size -= 1;
		start_pos.y = Random.Range (-1*size,size);
		newEnemy.transform.position = start_pos;

	}
}
