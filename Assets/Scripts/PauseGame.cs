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

	public void loadScrollUpdate()
	{
		Debug.Log("loadint saves list");
		foreach (Transform child in scrollLoadContent.transform)
		{
			Destroy(child.gameObject);
		}
		foreach (LevelSerializer.SaveEntry sg in LevelSerializer.SavedGames[LevelSerializer.PlayerName]) {
			GameObject _saving = Instantiate(saving, scrollLoadContent.transform);
			_saving.GetComponentInChildren<TextMeshProUGUI>().
				SetText(" " + sg.Caption);
			_saving.GetComponent<Saving>().saveEntry = sg;
        }
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
