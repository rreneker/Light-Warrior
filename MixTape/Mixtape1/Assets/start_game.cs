using UnityEngine;
using System.Collections;

public class start_game : MonoBehaviour {

	public void NextLevelButton(int index)
	{
		Application.LoadLevel(index);
	}
	public void NextLevelButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
