using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public LayerMask CollisionLayer;
	RaycastHit hit;
	RaycastHit positionHit;
	public Vector3 VerticalPosition;
	public float AccDown;
	public float VerticalVelocity = 0;
	public float fallDistance = 0.1f;
	public float groundDistance = 0.09f;

	// Update is called once per frame
	void FixedUpdate () {

		VerticalPosition = transform.position;

		if (isGrounded) {
			if (VerticalVelocity < 0f) {
				VerticalVelocity = 0f;
			}
		} else {
			VerticalVelocity -= AccDown * Time.fixedDeltaTime;
		}

		VerticalPosition.y += VerticalVelocity * Time.fixedDeltaTime;

		if (VerticalPosition != transform.position) {
			transform.position = PositionCorrectly(transform.position, VerticalPosition, fallDistance);
		}

	}

	public bool isGrounded {
		get {
			if (Physics.Raycast (transform.position, Vector3.down, out hit, 1f, CollisionLayer)) {
				if (hit.distance <= fallDistance) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
	}

	Vector3 PositionCorrectly(Vector3 pointA, Vector3 pointB, float distanceFromB) {

		if (Physics.Linecast (pointA, pointB, out positionHit, CollisionLayer)) {
			return pointA + (pointB - pointA).normalized * (positionHit.distance - groundDistance);
		} else {
			return pointB;
		}

	}
		
}
