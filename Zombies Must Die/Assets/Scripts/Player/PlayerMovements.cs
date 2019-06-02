using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : PlayerBehavior
{
    CharacterController cc;
    Transform cam;
    Inputs i;
	Vector3 moveDirection;

    [Range(1, 15)]
	public float speedWhileAiming = 2;
	[Range(1, 15)]
	public float speedWhileNotAiming = 4;

	public float jumpForce = 8;
	public float gravity = 20;
	private float speed;

	private void Start()
	{
		cc = GetComponent<CharacterController>();
        i = GetComponent<Inputs>();
    }

    void Update()
    {
        if (networkObject == null) return;

        if(cam == null) cam = Camera.main.transform;

        if (networkObject.IsOwner)
        {
            Vector2 input = new Vector2(i.horizontal, i.vertical) * speed * Time.deltaTime;
            Vector2 inputDir = input.normalized;

            if (inputDir != Vector2.zero || i.isAiming || i.isShooting)
                transform.eulerAngles = Vector3.up * cam.eulerAngles.y;

            speed = i.isAiming ? speedWhileAiming : speedWhileNotAiming;

            if (cc.isGrounded)
            {
                moveDirection = new Vector3(i.horizontal, 0.0f, i.vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;

                if (i.isJumping)
                {
                    moveDirection.y = jumpForce;
                }
            }


            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            cc.Move(moveDirection * Time.deltaTime);
        }
	}
}
