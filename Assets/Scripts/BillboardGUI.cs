using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Point and scale this canvas at the player
public class BillboardGUI : MonoBehaviour {

	float scaleAdjust = 0.22f;

	Transform tform;

	void Start() {
		tform = GameObject.FindWithTag("MainCamera").transform;
	}

	void Update() {
		transform.rotation = tform.rotation;
		transform.localScale = Vector3.one * ((tform.position - transform.parent.parent.transform.position).magnitude * scaleAdjust);
	}
}