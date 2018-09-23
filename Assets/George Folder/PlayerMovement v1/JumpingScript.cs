using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour {

	public Gravity GravityPlugin;

	public float JumpVelocity = 10f;

	// Update is called once per frame
	void Update () {

		if (GravityPlugin.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				GravityPlugin.VerticalVelocity = JumpVelocity;
			}
		}
		
	}
}
