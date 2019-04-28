using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public class Inputs : PlayerBehavior
{
    public bool isJumping;
    public bool isAiming;
    public bool isShooting;
    public float vertical;
    public float horizontal;
    public float mouseY;

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

            networkObject.horizontal = horizontal;
            networkObject.vertical = vertical;
            networkObject.isJumping = isJumping;
            networkObject.isShooting = isShooting;
            networkObject.isAiming = isAiming;
        }
        else
        {
            horizontal = networkObject.horizontal;
            vertical = networkObject.vertical;
            isJumping = networkObject.isJumping;
            isShooting = networkObject.isShooting;
            isAiming = networkObject.isAiming;
        }
    }
}
