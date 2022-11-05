using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

	public GameObject DroppedPiecePrefab;

	public float spawnDelay;
	public float piecePointValue;

	Transform dropLocation;

	private void Start() {
		dropLocation = gameObject.transform.Find("DropLocation");
		InvokeRepeating("SpawnPiece", GameManager.DROPPER_START_DELAY, spawnDelay);
	}

	protected virtual void SpawnPiece() {
		if (DroppedPiecePrefab == null) {
			Debug.LogWarning("No DroppedPiecePrefab selected!");
			return;
		}

		GameObject piece = Instantiate(DroppedPiecePrefab, dropLocation.transform.position, DroppedPiecePrefab.transform.rotation);
		Piece pScript = piece.GetComponent<Piece>();
		pScript.pointValue = piecePointValue;
	}

}
