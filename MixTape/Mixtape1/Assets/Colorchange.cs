using UnityEngine;
using System.Collections;

public class Colorchange : MonoBehaviour {

	public GameObject Controller;
	public float init_health;
	public float curr_health;

	// Use this for initialization
	void Start () {
		Controller = GameObject.Find ("controller");
		controller shit = Controller.GetComponent("controller") as controller;
		init_health = shit.wall_health;
	}
	
	// Update is called once per frame
	void Update () {
		controller shit = Controller.GetComponent("controller") as controller;
		curr_health = shit.wall_health;
		float percent = curr_health / init_health;

		this.GetComponent<Renderer>().material.color = new Color(1-percent,percent,0.0f,1.0f);

	
	}
}
