using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyPad : MonoBehaviour {

	public Material unreadyMat;
	public Material readyMat;
	public GameObject objectLink;

	Humanoid playerHum;
	MeshRenderer mr;
	Light lightComp;
	TextMeshProUGUI textObj;

	float price;

	// Start is called before the first frame update
	void Start() {
		//objectLink.SetActive(false);
		playerHum = GameObject.FindGameObjectWithTag("Player").GetComponent<Humanoid>();
		mr = GetComponent<MeshRenderer>();
		textObj = GetComponentInChildren<TextMeshProUGUI>();
		lightComp = GetComponent<Light>();

		playerHum.OnPlayerPointsChanged += OnPlayerPointsChanged;

		price = objectLink.GetComponent<BuyPadData>().objectPrice;
		textObj.SetText(objectLink.GetComponent<BuyPadData>().objectName + ": " + price + " pts");

		OnPlayerPointsChanged(0, playerHum.points);
	}

	void OnPlayerPointsChanged(float amnt, float currPoints) {
		if (currPoints >= price) {
			mr.material = readyMat;
			lightComp.enabled = true;
		} else {
			mr.material = unreadyMat;
			lightComp.enabled = false;
		}
	}

	void OnTriggerStay(Collider collision) {
		if (collision.gameObject.CompareTag("Player")) {
			if (playerHum.points >= price) {
				playerHum.RemovePoints(price);
				objectLink.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}

}
