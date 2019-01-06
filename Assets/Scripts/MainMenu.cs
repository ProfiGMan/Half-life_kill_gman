using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	void Start()
	{
		Time.timeScale = 1;
		if(!File.Exists(Application.persistentDataPath + "/player.bin"))
		{
			GameObject resumeButton;
			resumeButton = GameObject.Find("ResumeGameButton");
			if(resumeButton == null) 
			{
				Debug.LogWarning("Can't find the resume game button object");
			}
			else resumeButton.SetActive(false);
		}
	}
	public void exitPressed()
	{
		Application.Quit();
	}

	public void resumePressed()
	{
		SaveLoadGame.load();
	}
}
