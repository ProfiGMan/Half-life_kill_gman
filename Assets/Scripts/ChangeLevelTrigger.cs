using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelTrigger : MonoBehaviour {
	public float range = 2;
	public bool saveGameTrigger = false;
	public bool HorizontalNextLevelTrigger = false;
	public bool VerticalNextLevelTrigger = true;
	public bool ThereIsNextLevelTrigger = false;
	public GameObject NextLevelTrigger;
	public bool HorizontalPreviousLevelTrigger = false;
	public bool VerticalPreviousLevelTrigger = true;
	public bool ThereIsPreviousLevelTrigger = false;
	public GameObject PreviousLevelTrigger;
	public bool[] dieHorizontal;
	public bool[] dieVertical;
	public GameObject[] dieTriggers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < dieTriggers.Length; i++)
		{
			if((transform.position.x < 
			dieTriggers[i].transform.position.x + range && transform.position.x > 
			dieTriggers[i].transform.position.x - range && dieVertical[i]) ||
			(transform.position.y < 
			dieTriggers[i].transform.position.y + range && transform.position.y > 
			dieTriggers[i].transform.position.y - range && dieHorizontal[i]))
			{
				Respawn.respawnSceneIndex = SceneManager.GetActiveScene().buildIndex;
				SceneManager.LoadScene("onDeapth");
				return;
			}
		}

		if(ThereIsNextLevelTrigger)
		{
			if((transform.position.x < 
			NextLevelTrigger.transform.position.x + range && transform.position.x > 
			NextLevelTrigger.transform.position.x - range && VerticalNextLevelTrigger) ||
			(transform.position.y < 
			NextLevelTrigger.transform.position.y + range && transform.position.y > 
			NextLevelTrigger.transform.position.y - range && HorizontalNextLevelTrigger))
			{
				int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
				SceneManager.LoadScene(nextScene);
				if(saveGameTrigger) 
					SaveLoadGame.save(SceneManager.GetSceneByBuildIndex(nextScene).name);
				return;
			}
		}
		if(ThereIsPreviousLevelTrigger)
		{
			if((transform.position.x < 
			PreviousLevelTrigger.transform.position.x + range && transform.position.x > 
			PreviousLevelTrigger.transform.position.x - range && VerticalPreviousLevelTrigger) ||
			(transform.position.y < 
			PreviousLevelTrigger.transform.position.y + range && transform.position.y > 
			PreviousLevelTrigger.transform.position.y - range && 
			HorizontalPreviousLevelTrigger))
			{ 
				SceneManager.LoadScene(
					SceneManager.GetActiveScene().buildIndex - 1);
				return;
			}
		}
	}
}
