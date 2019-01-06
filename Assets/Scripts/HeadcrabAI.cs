using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadcrabAI : EnemyAI {

	public Rigidbody2D rb;

	public float distToDamage = 0.3f;

	bool attacking = false;
	float rotationScale = 30;

	public Collision2D lastCollision = null;
	override public void attack()
	{
		if(attacking || !colliding) return;
		float xForce = 600f;
		float xVal = 0f;
		if(facingRight) xVal = xForce;
		else xVal = -xForce;
		if(!GetComponent<Waiter>().waiting) 
		{
			rb.AddForce(new Vector3(xVal, 260, 100));
			float dist = transform.position.x - target.position.x;
			transform.eulerAngles = new Vector3(0, 0, getRotation());;
			animator.SetBool("jumping", true);
			StartCoroutine(Wait());
			attacking = true;
		}
		GetComponent<Waiter>().wait(2f);
	}

	override public void OnCollisionEnter2DSpecific(Collision2D collision)
	{
		collisionCount++;
		colliding = true;
		lastCollision = collision;
		if(attacking)
		{
			attacking = false;
			if(lastCollision.transform == target) 
				target.GetComponent<Health>().takeDamage(10);
			transform.eulerAngles = new Vector3(0, 0, 0);
			animator.SetBool("jumping", false);
		}
	}

	override public void OnCollisionExit2DSpecific(Collision2D collision)
	{
		if(--collisionCount <= 0) colliding = false;
	}

	float getRotation()
	{
		if(facingRight) return rotationScale;
		else return -rotationScale;
	}

	IEnumerator Wait(){
     	yield return new WaitForSeconds (0.2f);
 	}
}
