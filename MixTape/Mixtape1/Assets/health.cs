using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	public float red_val = 1.0f;
	public float green_val = 1.0f;
	public float blue_val = 1.0f;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = new Color(red_val,green_val,blue_val,1.0f);
	}

	void OnTriggerEnter(Collider other){
		GameObject stuff = other.gameObject;
		if (stuff.name == "bullet") {
			bullet shit = stuff.GetComponent("bullet") as bullet;
			if(shit.color == colour.red){
				red_val = 0.0f;
			}else if(shit.color == colour.green){
				green_val = 0.0f;
			}else if(shit.color == colour.blue){
				blue_val = 0.0f;
			}

			if(green_val == 0.0f && blue_val == 0.0f && red_val == 0.0f){
				Destroy(this.gameObject);
				movement mov = player.GetComponent("movement") as movement;
				mov.health += 50;
			}

		}

	}
}
