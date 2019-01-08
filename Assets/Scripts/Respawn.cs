﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	public static int respawnSceneIndex = 0;

	public static int lastSceneBeginHealth = 100;

	public void respawn() {
		Health.currentHealth = lastSceneBeginHealth;
		SceneManager.LoadScene(respawnSceneIndex);
	}
}
