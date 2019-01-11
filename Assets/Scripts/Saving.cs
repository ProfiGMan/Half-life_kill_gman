using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour {
	public static LevelSerializer.SaveEntry chosenSavingEntry; 
	public LevelSerializer.SaveEntry saveEntry;
	public void setChosen()
	{
		chosenSavingEntry = saveEntry;
	}
}
