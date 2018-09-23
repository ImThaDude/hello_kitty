using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 0.1f;
	public Vector3 movementVector = Vector3.zero;
	public Vector3 directionVector;
	public Quaternion playerRotation;

	public Gravity GravityPlugin;

	// Update is called once per frame
	void FixedUpdate () {

		if (GravityPlugin.isGrounded) {
			movementVector.z = Input.GetAxis ("Vertical");
			movementVector.x = Input.GetAxis ("Horizontal");
			playerRotation = transform.rotation;
		}

		//Simulating Physics for movement.
		if (movementVector != Vector3.zero) {
			directionVector = movementVector.normalized;
			transform.position += playerRotation * directionVector * speed * Time.fixedDeltaTime;
		}

	}

}
