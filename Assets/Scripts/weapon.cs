using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
	public Transform Player;
	public GameObject Handed;
	public GameObject thisWhole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(Player.GetComponentInChildren<handedCrowbar>() != null) return;
		if(collision.transform == Player) 
		{
			Instantiate(Handed, Player);
			this.gameObject.SetActive(false);
			Destroy(this.gameObject, 2f);
			//Destroy(thisWhole);
		}
	}
}
