using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Animator animator;

	public float runSpeed = 40f;

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

		// if((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) &&
		// (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) &&
		// Input.GetButtonDown("Jump"))
		// {
		// 	longJump = true;
		// 	Debug.Log("long jump");
		// }
		// else 
		if (Input.GetButtonDown("Jump") && !waiter.waiting)
		{
			waiter.wait(0.05f);
			jump = true;
			animator.SetBool("IsJumping", true);
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
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
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
}