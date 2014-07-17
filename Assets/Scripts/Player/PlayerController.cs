using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// Movement Config
	public float gravity = -15f;
	public float runSpeed = 2f;
	public float jumpHeight = 1f;
	private bool isJumping = false;

	// Animation States
	private int idleState = Animator.StringToHash("Idle");
	private int runState = Animator.StringToHash("Run");
	private int jumpState = Animator.StringToHash("Jump");

	private CharacterController2D controller;
	private Animator animator;
	private Vector3 velocity;

	void Awake () {
		controller = GetComponent<CharacterController2D>();
		animator = GetComponent<Animator>();
	}

	void Update() {
		// grab our current velocity to use as a base for all calculations
		velocity = controller.velocity;

		if (controller.isGrounded) {
			velocity.y = 0;
			isJumping = false;
		}

		// horizontal input
		if (Input.GetKey(KeyCode.RightArrow)) {
			velocity.x = runSpeed;
			goRight();

			if (controller.isGrounded) {
				animator.Play(runState);
			}
		} else if(Input.GetKey(KeyCode.LeftArrow)) {
			velocity.x = -runSpeed;

			goLeft();
			
			if (controller.isGrounded) {
				animator.Play(runState);
			}
		} else {
			velocity.x = 0;
			
			if (controller.isGrounded) {
				animator.Play(idleState);
			}
		}

		if(Input.GetKey(KeyCode.UpArrow) && !isJumping) {
			velocity.y = Mathf.Sqrt(3f * jumpHeight * -gravity);
			animator.Play(jumpState);
			isJumping = true;
		}

		// apply gravity before moving
		velocity.y += gravity * Time.deltaTime;

		controller.move (velocity * Time.deltaTime);
	}

	private void goLeft() {
		if (transform.localScale.x > 0f)
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	private void goRight() {
		if (transform.localScale.x < 0f)
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
