using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handedCrowbar : MonoBehaviour {
	public static bool pickedUp = false;
	Waiter waiter;
	bool firingToRight = true;
	bool damaging = false;
	public float rotation = 25;
	public CircleCollider2D aboveCollider;

	// Use this for initialization
	void Start () {
		pickedUp = true;
		waiter = GetComponent<Waiter>();	
		aboveCollider.enabled = false;	
	}

	void FixedUpdate()
	{
		if(((Input.GetButton("Fire1") && Input.touchCount == 0) || TouchControls.isFiring) 
		&& !waiter.waiting)
		{
			if(firingToRight)
			{
				Vector3 currentAngles = transform.eulerAngles;
				currentAngles.z = rotation;
				transform.eulerAngles = currentAngles;
				aboveCollider.enabled = true;
				firingToRight = false;
				damaging = true;
				//Debug.Log("fucking");
			}
			else if(!firingToRight)
			{
				Vector3 currentAngles = transform.eulerAngles;
				currentAngles.z = -rotation;
				transform.eulerAngles = currentAngles;
				aboveCollider.enabled = false;
				firingToRight = true;
				damaging = false;
			}
			waiter.wait(0.1f);
		}
		if(Input.GetButtonUp("Fire1") || !TouchControls.isFiring)
		{
			Vector3 currentAngles = transform.eulerAngles;
			currentAngles.z = 0;
			transform.eulerAngles = currentAngles;
			aboveCollider.enabled = false;
			firingToRight = true;
			damaging = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "npc" && damaging)
		{
			damaging = false;
			collision.gameObject.GetComponent<EnemyAI>().takeDamage(10);
		}
	}
}
