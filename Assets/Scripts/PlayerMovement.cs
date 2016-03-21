using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;
	private Vector3 movement;  				// Vector3 variable = (x,y,z)

	// Use this for initialization
	void Start () {

		// Gather components from the Player GameObject 
		playerAnimator = GetComponent<Animator> ();	
		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// Gather input from the keyboard 
		moveHorizontal = Input.GetAxisRaw("Horizontal");
		moveVertical = Input.GetAxisRaw("Vertical");
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 


	}

	/* From Unity Documentation: "FixedUpdate should be used instead of Update when dealing with Rigidbody. 
	   For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside 
	   FixedUpdate instead of every frame inside Update." */
	void FixedUpdate () { 

		// If players movement vector != 0....
		if (movement != Vector3.zero) {

			// ...then create a target rotation based on the movement vector...
			// Vector3.up = (0,1,0). It provides a reference for Unity that prevents a number of issues.
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			// ...and create another rotation that moves from the current rotation to the target rotation...
			/* Time.deltaTime is a float value that stores the amount of time between the current frame and when the previous 
			   frame was rendered. */ 
			Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);

			// ... and change the player's rotation to the new incremental rotation 
			playerRigidbody.MoveRotation(newRotation);

			// Then play the jump animation
			playerAnimator.SetFloat("Speed", 3f);
		} 

		// otherwise do not play the animation
		else {
			playerAnimator.SetFloat("Speed", 0f);
		} 
	}
}