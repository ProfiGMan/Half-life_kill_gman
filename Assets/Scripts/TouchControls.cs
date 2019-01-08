using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {
	public static bool isFiring = false;
	public static bool isUsing = false;
	public static bool isJumping = false;

	public void onFireDown()
	{
		isFiring = true;
	}

	public void onFireUp()
	{
		isFiring = false;
	}
	
	public void onUseDown()
	{
		isUsing = true;
	}

	public void onUseUp()
	{
		isUsing = false;
	}

	public void jump()
	{
		isJumping = true;
	}
}
