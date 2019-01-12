using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject spawn;
	public bool spawnAtSpawnPoint = false;
	public static bool loadWhenSpawn = false;
	public static bool saveWhenSpawn = false;
	public static LevelSerializer.SaveEntry loadEntry;
	public static string saveEntryName;

	// Use this for initialization
	void Start () {
		if(spawnAtSpawnPoint) transform.position = spawn.transform.position;
		if(loadWhenSpawn)
		{
			loadWhenSpawn = false;
			if(loadEntry == null) Debug.LogError("loadEntry is not intialized");
			else LevelSerializer.LoadNow(loadEntry.Data);
		}
		Debug.Log(saveWhenSpawn);
		if(saveWhenSpawn)
		{
			saveWhenSpawn = false;
			if(saveEntryName == null) saveEntryName = "autosave";
			SaveLoadGame.save(saveEntryName);
		}
	}
}
