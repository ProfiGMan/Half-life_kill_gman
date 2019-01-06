using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
	public GameObject scrollLoadContent;
	public Button resumeButton;
	public GameObject pausePanel;
	public GameObject saving;
	string level;
	void Update()
	{
		if(Input.GetButtonDown("Pause"))
		{
			if(pausePanel.activeSelf)
			{
				resumeButton.onClick.Invoke();
			}
			else
			{
				GetComponent<Button>().onClick.Invoke();
			}
		}
	}
	public void pause()
	{
		Time.timeScale = 0f;
	}

	public void resume()
	{
		Time.timeScale = 1f;
	}

	public void load()
	{
		Spawn.loadWhenSpawn = true;
		Spawn.loadData = Saving.chosenSavingData;
		Debug.Log(Saving.chosenSavingName.Split(' ')[2]);
		SceneManager.LoadScene(Saving.chosenSavingName.Split(' ')[2]);
	}

	public void save()
	{
		LevelSerializer.SaveGame("autosave");
	}

	public void loadScrollUpdate()
	{
		foreach (Transform child in scrollLoadContent.transform)
		{
			Destroy(child.gameObject);
		}
		foreach (LevelSerializer.SaveEntry sg in LevelSerializer.SavedGames[LevelSerializer.PlayerName]) {
            GameObject _saving = Instantiate(saving, scrollLoadContent.transform);
			_saving.GetComponentInChildren<TextMeshProUGUI>().
				SetText(" " + sg.Caption);
			_saving.GetComponent<Saving>().data = sg.Data;
        }
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
