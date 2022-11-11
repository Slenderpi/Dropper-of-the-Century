using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {

    const float GRAVITY = -9.8f;

    CharacterController controller;
    Transform cam;

    [SerializeField]
    Vector3 lastJumpVelocity;

    [SerializeField]
    bool IsGrounded;

    public float speed = 3f;
    public float jumpSpeed = 5f;
    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;

    [SerializeField]
    bool jump;

	private void Awake() {
		controller = GetComponent<CharacterController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetButton("Jump");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * (controller.isGrounded ? 1 : 0.8f) * Time.deltaTime);
        }

        if (IsGrounded) {
            if (jump) {
                print("Jumping!");
                lastJumpVelocity.y = jumpSpeed;
            }
		} else {
            lastJumpVelocity.y += GRAVITY * Time.deltaTime;
        }
        controller.Move(lastJumpVelocity * Time.deltaTime);
    }

	private void FixedUpdate() {
        CheckGrounded();
	}

	private void CheckGrounded() {
        IsGrounded = false;
        float capsuleHeight = Mathf.Max(controller.radius * 2f, controller.height);
        Vector3 capsuleBottom = transform.TransformPoint(controller.center - Vector3.up * capsuleHeight / 2f);
        float radius = transform.TransformVector(controller.radius, 0f, 0f).magnitude;
        Ray ray = new Ray(capsuleBottom + transform.up * 0.01f, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, radius * 2f)) {
            float normalAngle = Vector3.Angle(hit.normal, transform.up);
            if (normalAngle <= controller.slopeLimit) {
                float maxDist = radius / Mathf.Cos(Mathf.Deg2Rad * normalAngle) + 0.02f; // 0.02f error
                //print("hit.distance: " + hit.distance + "; maxDist: " + maxDist);
                if (hit.distance <= maxDist)
                    IsGrounded = true;
            }
        }
    }

}
