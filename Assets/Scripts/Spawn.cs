using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject spawn;
	public bool spawnAtSpawnPoint = false;
	public static bool loadWhenSpawn = false;
	public static string loadData;

	// Use this for initialization
	void Start () {
		if(spawnAtSpawnPoint) transform.position = spawn.transform.position;
		if(loadWhenSpawn)
		{
			loadWhenSpawn = false;
			if(loadData == null) Debug.LogError("loadData is not intialized");
			else LevelSerializer.LoadNow(loadData);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
