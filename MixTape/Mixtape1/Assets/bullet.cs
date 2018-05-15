using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public float speed = 10.0f;

	public colour color;

	public float max_x;

	// Use this for initialization
	void Start () {
		float camsize = Camera.main.orthographicSize;
		max_x = (camsize *16)/9;
		if (color == colour.red) {
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
		} else if (color == colour.blue) {
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.blue);
		} else if (color == colour.green) {
			this.GetComponent<Renderer> ().material.SetColor ("_Color", Color.green);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.x > max_x) {
			Destroy (this.gameObject);
		} else {
			Vector3 cur_pos = this.transform.position;
			cur_pos.x += speed * Time.deltaTime;
			this.transform.position = cur_pos;
		}
	
	}
}
