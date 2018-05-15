using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public int score;
	public string Pname;
	public InputField field;
	public Text text;
	public bool entered;

	void Start () {
		entered = false;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject pers = GameObject.Find("peristant_info");
		persistance stuff = pers.GetComponent("persistance") as persistance;
		score = stuff.score;
		Pname = field.text;

		if(Input.GetKeyDown("return") && entered == false){
			add_score (Pname,score);
			entered = true;
		}

		if (entered == true) {
			text.text = "Score Submitted";
		} else {
			text.text = "Enter Name and press Enter to Enter Score";
		}
	
	}

	void add_score(string name, int score){

		int oldscore, newscore;
		string oldname, newname;
		newscore = score;
		newname = name;

		for (int i = 0; i < 10; i++) {

			if(PlayerPrefs.HasKey(i+"HScore")){
				if(PlayerPrefs.GetInt(i+"HScore")< newscore){
					oldname = PlayerPrefs.GetString(i+"HScoreName");
					oldscore = PlayerPrefs.GetInt(i+"HScore");
					PlayerPrefs.SetInt(i+"HScore",newscore);
					PlayerPrefs.SetString(i+"HScoreName",newname);
					newscore = oldscore;
					newname = oldname;

				}
			}else{
				PlayerPrefs.SetInt(i+"HScore",newscore);
				PlayerPrefs.SetString(i+"HScoreName",newname);
				newscore = 0;
				newname = "";
			}
		}


	}
}
