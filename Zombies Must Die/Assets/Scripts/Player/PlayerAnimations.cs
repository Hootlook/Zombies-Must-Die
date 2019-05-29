using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

public class PlayerAnimations : PlayerBehavior
{
    Animator a;
	CharacterController cc;
    CameraController cameraController;
    PlayerAudio pa;
    WeaponManager wm;
    PlayerSetup ps;
    Inputs i;

    private void Start()
    {
        a = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
        i = GetComponent<Inputs>();
        ps = GetComponent<PlayerSetup>();
        pa = GetComponent<PlayerAudio>();
        wm = GetComponent<WeaponManager>();
    }

    void Update()
    {
        if (networkObject == null) return;

        cameraController = GameObject.Find("Camera(Clone)").GetComponent<CameraController>();

        float aiming = i.isAiming ? 1 : 0;
        float angleX = networkObject.IsOwner ? -cameraController.vertical : -ps.vertical;

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
            if (ps.isGrounded)
            {
                a.SetBool("Aiming", i.isAiming);
            }
        }
    }

    public void ThrowingEvent()
    {
        Transform t = wm.weaponBone.Find("Grenade");

        if (networkObject.IsOwner && t != null)
        {
            GrenadeBehavior g = NetworkManager.Instance.InstantiateGrenade(position: t.position, rotation: t.rotation);
            g.GetComponent<Rigidbody>().isKinematic = false;
            g.GetComponent<Rigidbody>().AddForce(cameraController.transform.forward * 500);
            g.GetComponent<Rigidbody>().AddTorque(t.up * 500);
        }

        pa.PlaySound("Throwing");
    } 
}
