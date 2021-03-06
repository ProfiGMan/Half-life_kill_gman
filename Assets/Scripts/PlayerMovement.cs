﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Animator animator;

	public float runSpeed = 40f;
	public VirtualJoystick joystick;

	float horizontalMove = 0f;
	bool jump = false;
	bool longJump = false;
	bool crouch = false;

	bool trulyLanding = true;
	Waiter waiter;

	void Start()
	{
		waiter = GetComponent<Waiter>();
	}

	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0) return;

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if(joystick.InputDirection.x > 0.2f) horizontalMove =
			runSpeed;
		else if(joystick.InputDirection.x < -0.2f) horizontalMove =
			-runSpeed;

		if((Input.GetKey(KeyCode.LeftShift)) &&
		(Input.GetButton("Horizontal")) &&
		Input.GetButtonDown("Jump"))
		{
			longJump = true;
			Debug.Log("long jump");
		}
		else 
		if ((TouchControls.isJumping || Input.GetButtonDown("Jump")) && !waiter.waiting)
		{
			waiter.wait(0.05f);
			TouchControls.isJumping = false;
			// jump = true;
			// animator.SetBool("IsJumping", true);
			Jump();
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate ()
	{
		var absSpeed = 
			Mathf.RoundToInt(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		if(horizontalMove < 0.2 && horizontalMove > -0.2) absSpeed = 0;
		animator.SetFloat("Speed", absSpeed);
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void OnLanding()
	{
		if(animator.GetBool("IsJumping"))
		{
			trulyLanding = !trulyLanding;
			if(trulyLanding)
			{
				animator.SetBool("IsJumping", false);
			}
		}
	}

	public void Jump()
	{
		if(controller.m_Grounded) animator.SetBool("IsJumping", true);
		controller.Move(0, crouch, true);
	}
}