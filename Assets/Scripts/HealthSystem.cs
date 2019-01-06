using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	public Transform Player;
	public float range = 1f;

	public float amountOfHealth = 45;

	public Sprite EmptySprite;
	Waiter waiter;

	SpriteRenderer spriteRenderer;

	void Start()
	{
		waiter = GetComponent<Waiter>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Health.getCurrentHealth() >= 100 || waiter.waiting) return;
		if(Input.GetButton("Use") && amountOfHealth > 0)
		{
			var dif = Player.position - transform.position;
			if(dif.x < range && dif.x > -range &&
			dif.y < range && dif.y > -range)
			{
				Player.GetComponent<Health>().health(1);
				amountOfHealth--;
				waiter.wait(0.12f);
			}
		}
		if(amountOfHealth <= 0) 
		{
			spriteRenderer.sprite = EmptySprite;
		}
	}
}
