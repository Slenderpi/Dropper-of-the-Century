using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour {

	Humanoid owner;

	private void Start() {
		owner = GameObject.FindGameObjectWithTag("Player").GetComponent<Humanoid>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Piece")) {
			Piece piece = other.GetComponent<Piece>();

			owner.AddPoints(piece.pointValue);

			piece.DestroyPiece();
		}
	}

}
