using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

	[SerializeField]
	Vector3 direction;

	void Start() {
		direction = direction.normalized;
	}

	private void OnCollisionStay(Collision collision) {
		if (collision.gameObject.GetComponent<Rigidbody>() != null) {
			//BodyVelocity vel = collision.gameObject.AddComponent<BodyVelocity>();
			//vel.velocity = direction * GameManager.CONVEYOR_VELOCITY;
			collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * GameManager.CONVEYOR_VELOCITY,
																	ForceMode.Acceleration);
		}
	}

}
