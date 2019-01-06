using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : EnemyAI {
    void OnCollisionEnter2D(Collision2D collision)
	{
        collisionCount++;
		colliding = true;
	}

    void OnCollisionExit2D(Collision2D collision)
	{
		if(--collisionCount <= 0) colliding = false;
	}
}
