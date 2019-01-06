using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
	public string level;
	public int health;
	public string[] handedWeapons; 
	public PlayerData(string lv, int hlth, string[] weapons)
	{
		level = lv;
		health = hlth;
		handedWeapons = weapons;
	}
}
