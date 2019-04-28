using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public class PlayerAnimations : PlayerBehavior
{
    Animator a;
	CharacterController cc;
    CameraController cameraController;
    PlayerNetworkSetup pns;
    Inputs i;

    private void Start()
    {
        a = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
        i = GetComponent<Inputs>();
        pns = GetComponent<PlayerNetworkSetup>();
    }
     
    void Update()
    {
        if (networkObject == null) return;

        cameraController = GameObject.Find("Camera(Clone)").GetComponent<CameraController>();

        float aiming = i.isAiming ? 1 : 0;
        float angleX = networkObject.IsOwner ? -cameraController.vertical : -pns.vertical;

        a.SetFloat("AngleX", angleX);
        a.SetFloat("Vertical", i.vertical);
        a.SetFloat("Horizontal", i.horizontal);
        a.SetBool("Shooting", i.isShooting);
        a.SetLayerWeight(1, aiming);


        if (networkObject.IsOwner)
        {
            if (cc.isGrounded)
            {
                a.SetBool("Aiming", i.isAiming);
            }
        }
        else
        {
            if (pns.isGrounded)
            {
                a.SetBool("Aiming", i.isAiming);
            }
        }

		
    }

}
