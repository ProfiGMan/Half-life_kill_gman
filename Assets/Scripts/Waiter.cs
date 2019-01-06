using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour {

	public bool waiting = false;

	float seconds;

	public void wait(float sec)
	{
		if(waiting) return;
		seconds = sec;
		StartCoroutine(Wait());
	}

	 IEnumerator Wait(){
    	waiting = true;
     	yield return new WaitForSeconds (seconds);
		waiting = false;
 	}
}
