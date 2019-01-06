using UnityEngine;
using System.Collections;
public class EnemyAI : MonoBehaviour {
	public Transform target;

	public float xRangeBeforeLoose = 10f;
	public float yRangeBeforeLoose = 5f;	

	public float xRangeBeforeSee = 7f;
	public float yRangeBeforeSee = 4f;

	public float distanceBeforeAttacking = 5;

	public float speed = 5f;

	public bool facingRight = false;

	bool seeingTarget = false;

	public bool colliding = false;	

	public int collisionCount = 0;

	public int health = 10;

	public Animator animator;
	bool targetChased = false;
	void FixedUpdate () {
		var dist = transform.position - target.position;

		bool xDistBeforeLoose = dist.x < xRangeBeforeLoose && dist.x > -xRangeBeforeLoose;
		bool yDistBeforeLoose = dist.y < yRangeBeforeLoose && dist.y > -yRangeBeforeLoose;

		bool xTargetSeen = dist.x < xRangeBeforeSee && dist.x > -xRangeBeforeSee;
		bool yTargetSeen = dist.y < yRangeBeforeSee && dist.y > -yRangeBeforeSee;

		if(xTargetSeen && yTargetSeen) seeingTarget = true;
		else if(seeingTarget == false) return;
		
		if(!xDistBeforeLoose || !yDistBeforeLoose) 
		{
			seeingTarget = false;
			return;
		}

		if(!targetChased) 
		{
			Vector3 pos;
			pos = Vector2.MoveTowards(transform.position, target.position, speed / 100);
			pos.z = 100;
			pos.y = transform.position.y;
			if(pos.x - transform.position.x > 0 && !facingRight && colliding) Flip();
			if(pos.x - transform.position.x < 0 && facingRight && colliding) Flip();
			if(animator != null) animator.SetFloat("speed", Mathf.Abs(transform.position.x - pos.x));
			transform.position = pos;
		}
		if(dist.x < distanceBeforeAttacking) attack();
	}

	public void takeDamage(int amount)
	{
		health -= amount;
		if(health <= 0) {
			if(animator != null) animator.SetBool("dead", true);
			tag = "deadNpc";
			Destroy(this);
		}
	}
	
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public virtual void attack() {}

	public virtual void OnCollisionEnter2DSpecific(Collision2D collision) {}
	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.tag == "Player") 
		{
			targetChased = true;
		}
		OnCollisionEnter2DSpecific(collision);
	}

	public virtual void OnCollisionExit2DSpecific(Collision2D collision) {}
	void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player") 
		{
			targetChased = false;
		}
		OnCollisionExit2DSpecific(collision);
	}
}
