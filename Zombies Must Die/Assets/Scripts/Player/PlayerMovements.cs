using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    CharacterController cc;
    Transform cameraT;
	Vector3 moveDirection;
	
	[Range(1, 15)]
	public float speedWhileAiming = 2;
	[Range(1, 15)]
	public float speedWhileNotAiming = 4;

	public float jumpForce = 8;
	public float gravity = 20;
	private float speed;

	void Start()
    {
        cc = GetComponent<CharacterController>();
		cameraT = Camera.main.transform;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero || Input.GetButton("Fire2") || Input.GetButton("Fire1"))
			transform.eulerAngles = Vector3.up * cameraT.eulerAngles.y;

		speed = Input.GetButton("Fire2") ? speedWhileAiming : speedWhileNotAiming;

		if (cc.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection = moveDirection * speed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpForce;
			}
		}

		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

		cc.Move(moveDirection * Time.deltaTime);

	}
}
