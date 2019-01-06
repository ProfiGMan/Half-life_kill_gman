using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour {

	public void StartNewGamePressed()
	{
		SceneManager.LoadScene("ep1lvl1");
	}
}
