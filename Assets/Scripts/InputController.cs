using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private CharacterController charController;

    [SerializeField]
    float vertical;
	[SerializeField]
    float horizontal;
    [SerializeField]
    bool jump;

    void Awake() {
        charController = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        // Get input values
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        charController.ForwardInput = vertical;
        charController.TurnInput = horizontal;
        charController.JumpInput = jump;
    }
}
