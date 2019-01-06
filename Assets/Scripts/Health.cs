using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour {

	public static int currentHealth = 100;

	static bool healthChanged = false;

	public int startHealth = -1;

	void Start()
	{
		healthText.GetComponent<TextMeshProUGUI>().
			SetText(currentHealth.ToString() + "%");
		int beginHealth = currentHealth;
		currentHealth = 100;
		if(startHealth == -1) 
		{
			takeDamage(100 - beginHealth);
		}
		else
		{
			takeDamage(currentHealth - startHealth);
		}
		Respawn.lastSceneBeginHealth = currentHealth;
	}

	void Update()
	{
		if(healthChanged) 
			healthText.GetComponent<TextMeshProUGUI>().
			SetText(currentHealth.ToString() + "%");
		healthChanged = false;
	}

	public GameObject healthText;
	public void takeDamage(int damage)
	{
		currentHealth -= damage;
		healthText.GetComponent<TextMeshProUGUI>().SetText(currentHealth.ToString() + "%");
		if(currentHealth <= 0)
		{
			Respawn.respawnSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene("onDeapth");
		}
	}

	public void health(int amount)
	{
		currentHealth += amount;
		if(currentHealth > 100) currentHealth = 100;
		healthText.GetComponent<TextMeshProUGUI>().SetText(currentHealth.ToString() + "%");
	}

	public static int getCurrentHealth()
	{
		return currentHealth;
	}

	public static void setCurrentHealth(int hlth)
	{
		currentHealth = hlth;
		healthChanged = true;
	}
}
