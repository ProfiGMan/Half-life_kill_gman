using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject spawn;
	public bool spawnAtSpawnPoint = false;
	public static bool loadWhenSpawn = false;
	public static LevelSerializer.SaveEntry loadEntry;

	// Use this for initialization
	void Start () {
		if(spawnAtSpawnPoint) transform.position = spawn.transform.position;
		if(loadWhenSpawn)
		{
			loadWhenSpawn = false;
			if(loadEntry == null) Debug.LogError("loadEntry is not intialized");
			else LevelSerializer.LoadNow(loadEntry.Data);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
