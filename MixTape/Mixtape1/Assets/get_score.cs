using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class get_score : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject pers = GameObject.Find("peristant_info");
		persistance stuff = pers.GetComponent("persistance") as persistance;
		score.text = stuff.score.ToString ();

	}
}
