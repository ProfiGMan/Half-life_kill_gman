using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saving : MonoBehaviour {
	public static string chosenSavingData; 
	public static string chosenSavingName;
	public string data;
	public void setChosen()
	{
		chosenSavingName = GetComponentInChildren<TextMeshProUGUI>().text;
		chosenSavingData = data;
	}
}
