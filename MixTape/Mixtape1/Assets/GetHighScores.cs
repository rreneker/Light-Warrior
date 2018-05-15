using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetHighScores : MonoBehaviour {

	public Text n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
	public Text s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;

	// Use this for initialization
	void Start () {
		n1.text = PlayerPrefs.GetString(0+"HScoreName");
		s1.text = PlayerPrefs.GetInt(0+"HScore").ToString();
		n2.text = PlayerPrefs.GetString(1+"HScoreName");
		s2.text = PlayerPrefs.GetInt(1+"HScore").ToString();
		n3.text = PlayerPrefs.GetString(2+"HScoreName");
		s3.text = PlayerPrefs.GetInt(2+"HScore").ToString();
		n4.text = PlayerPrefs.GetString(3+"HScoreName");
		s4.text = PlayerPrefs.GetInt(3+"HScore").ToString();
		n5.text = PlayerPrefs.GetString(4+"HScoreName");
		s5.text = PlayerPrefs.GetInt(4+"HScore").ToString();
		n6.text = PlayerPrefs.GetString(5+"HScoreName");
		s6.text = PlayerPrefs.GetInt(5+"HScore").ToString();
		n7.text = PlayerPrefs.GetString(6+"HScoreName");
		s7.text = PlayerPrefs.GetInt(6+"HScore").ToString();
		n8.text = PlayerPrefs.GetString(7+"HScoreName");
		s8.text = PlayerPrefs.GetInt(7+"HScore").ToString();
		n9.text = PlayerPrefs.GetString(8+"HScoreName");
		s9.text = PlayerPrefs.GetInt(8+"HScore").ToString();
		n10.text = PlayerPrefs.GetString(9+"HScoreName");
		s10.text = PlayerPrefs.GetInt(9+"HScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
