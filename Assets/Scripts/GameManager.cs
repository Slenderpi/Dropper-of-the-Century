using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public const float DROPPER_START_DELAY = 1.75f;

	public const float PIECE_LIFE_DURATION = 60;

	public const float CONVEYOR_VELOCITY = 9.6f;

	public enum PlayerState { Dead, Alive, Invincible };

	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

}
