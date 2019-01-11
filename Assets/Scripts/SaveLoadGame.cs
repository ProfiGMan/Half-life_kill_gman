﻿using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveLoadGame : MonoBehaviour {
	public static void load()
	{
		Debug.Log("loading");
		Spawn.loadWhenSpawn = true;
		Spawn.loadEntry = Saving.chosenSavingEntry;
		Debug.Log(Saving.chosenSavingEntry.Level);
		SceneManager.LoadScene(Saving.chosenSavingEntry.Level);
	}

	public static void save(string name = "autosave")
	{
		Debug.Log("saving");
		LevelSerializer.SaveGame(name);
	}

	public void loadLast() {
		var sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName];
		Saving.chosenSavingEntry = sg[sg.Count - 1];
		load();
	}

	public void nonStaticLoad()
	{
		load();
	}

	public void nonStaticSave() 
	{
		save();
	}

	public void nonStaticLoadLast()
	{
		loadLast();
	}
}
