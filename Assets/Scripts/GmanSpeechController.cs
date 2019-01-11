using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GmanSpeechController : MonoBehaviour {

	public TextAsset TextFile;
	string[] lines;
	int lineIndex = 0;

	public void next()
	{
		if(lines.Length == lineIndex + 1)
		{
			int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
			SceneManager.LoadScene(nextScene);
			SaveLoadGame.save("checkpoint");
		}
		else if(lines.Length != 0)
		{
			GetComponent<TextMeshProUGUI>().text = lines[lineIndex++];
		}
	}
	void Start () {
		if(TextFile != null)
		{
			lines = TextFile.text.Split('\n');
		}
		next();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("return"))
		{
			next();
		}
	}
}
