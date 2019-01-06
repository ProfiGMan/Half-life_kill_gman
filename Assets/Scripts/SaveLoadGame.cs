using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class SaveLoadGame {
	public static void save(string sceneName = null)
	{
		Debug.Log("save");
		if(sceneName == null) sceneName = SceneManager.GetActiveScene().name;
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.bin";
		FileStream stream = new FileStream(path, FileMode.Create);
		List<string> weapons = new List<string>();
		if(handedCrowbar.pickedUp) weapons.Add("crowbar_handed");
		formatter.Serialize(stream, new PlayerData(sceneName, 
			Health.getCurrentHealth(), weapons.ToArray()));
		stream.Close();
	}

	public static void load()
	{
		Debug.Log("loading the game");
		string path = Application.persistentDataPath + "/player.bin";
		if(!File.Exists(path))
		{
			Debug.LogError("No saved games found");
			return;
		}
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path, FileMode.Open);
		PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
		Debug.Log(playerData.level);
		SceneManager.LoadScene(playerData.level);
		Health.setCurrentHealth(playerData.health);
		stream.Close();
	}
}
