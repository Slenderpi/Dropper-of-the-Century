using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUIManager : MonoBehaviour {

	Humanoid playerHum;
	TextMeshProUGUI tmp;

	private void Awake() {
		playerHum = GameObject.FindGameObjectWithTag("Player").GetComponent<Humanoid>();
		tmp = gameObject.GetComponent<TextMeshProUGUI>();

		playerHum.OnPlayerPointsChanged += OnPlayerPointsChanged;
	}

	void OnPlayerPointsChanged(float amnt, float currPoints) {
		tmp.text = "Points: " + currPoints;
	}

}
