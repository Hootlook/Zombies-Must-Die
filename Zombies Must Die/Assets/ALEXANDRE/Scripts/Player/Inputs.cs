/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public class Inputs : PlayerBehavior
{
    public bool isJumping;
    public bool isAiming;
    public bool isUsing;
    public bool isShooting;
    public float vertical;
    public float horizontal;
    public float mouseY;
    public float mouseWheel;

    public override void PlayerId(RpcArgs args)
    {
        throw new System.NotImplementedException();
    }

    private void OnDisable()
	{
        isJumping = false;
        isShooting = false;
        isAiming = false;
        isUsing = false;
        horizontal = 0;
		vertical = 0;
		mouseY = 0;
        mouseWheel = 0;
	}

	private void Update()
    {
        if (networkObject == null) return;

        if (networkObject.IsOwner)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            mouseY = Input.GetAxis("Mouse Y");
            isJumping = Input.GetButton("Jump");
            isShooting = Input.GetButton("Fire1");
            isAiming = Input.GetButton("Fire2");
            isUsing = Input.GetButtonDown("Interact");
            mouseWheel = Input.GetAxis("MouseWheel");

            networkObject.horizontal = horizontal;
            networkObject.vertical = vertical;
            networkObject.isJumping = isJumping;
            networkObject.isShooting = isShooting;
            networkObject.isAiming = isAiming;
            networkObject.isUsing = isUsing;
        }
        else
        {
            horizontal = networkObject.horizontal;
            vertical = networkObject.vertical;
            isJumping = networkObject.isJumping;
            isShooting = networkObject.isShooting;
            isAiming = networkObject.isAiming;
            isUsing = networkObject.isUsing;
        }
    }
}
