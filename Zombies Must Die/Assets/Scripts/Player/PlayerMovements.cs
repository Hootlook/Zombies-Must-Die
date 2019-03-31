using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    CharacterController cc;
    Transform cameraT;
    float speed;
	[Range(1, 50)]
	public float speedWhileAiming = 10;
	[Range(1, 50)]
	public float speedWhileNotAiming = 20;
	public float jumpForce = 3;
	public float gravityMultiplier = 2;
	Vector3 moveDirection;
	Vector3 storeCurDir;

	void Start()
    {
        cc = GetComponent<CharacterController>();
		cameraT = Camera.main.transform;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero || Input.GetButton("Fire2"))
			transform.eulerAngles = Vector3.up * cameraT.eulerAngles.y;

		float storeY = moveDirection.y;
		moveDirection = ((transform.right * input.x) + (transform.forward * input.y)) * speed;
		moveDirection.y = storeY;

		moveDirection.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

		speed = Input.GetButton("Fire2") ? speedWhileAiming : speedWhileNotAiming;

		if (cc.isGrounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpForce;
				storeCurDir = moveDirection;
			}
		}
		else
		{
			cc.Move(storeCurDir * Time.deltaTime);
		}

		cc.Move(moveDirection * Time.deltaTime);

		
	}
}
