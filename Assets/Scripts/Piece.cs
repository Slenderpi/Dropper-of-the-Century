using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour {

	public float pointValue;

	//new Collider collider;

	// Start is called before the first frame update
	void Start() {
		//collider = GetComponent<Collider>();
		StartCoroutine(DestroyIfLifeExceeded(GameManager.PIECE_LIFE_DURATION));
	}

	// Update is called once per frame
	void Update() {

	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Untagged"))
			DestroyPiece();
	}

	public void DestroyPiece() {
		// TODO: Do fade effect first
		Destroy(gameObject);
	}

	IEnumerator DestroyIfLifeExceeded(float time) {
		yield return new WaitForSeconds(time);
		DestroyPiece();
	}

}
