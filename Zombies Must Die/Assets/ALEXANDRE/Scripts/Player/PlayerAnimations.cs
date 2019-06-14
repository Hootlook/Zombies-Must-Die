/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public class PlayerAnimations : PlayerBehavior
{
    Inputs i;
    Animator a;
    PlayerAudio pa;
    PlayerSetup ps;
    WeaponManager wm;
	CharacterController cc;
    
    public Transform spine;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        i = GetComponent<Inputs>();
        a = GetComponent<Animator>();
        ps = GetComponent<PlayerSetup>();
        pa = GetComponent<PlayerAudio>();
        wm = GetComponent<WeaponManager>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (networkObject == null) return;

        float aiming = i.isAiming ? 1 : 0;
        float angleX = networkObject.IsOwner ? -ps.cameraController.vertical : -ps.vertical;

        a.SetFloat("AngleX", angleX);
        a.SetFloat("Vertical", i.vertical);
        a.SetFloat("Horizontal", i.horizontal);
        a.SetBool("Shooting", wm.currentWeapon.isShooting);
        a.SetInteger("selectedWeapon", wm.weaponId);
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
        if (networkObject.IsOwner && wm.currentWeapon.transform.name == "Grenade")
        {
            wm.currentWeapon.isArmed = true;
        }

        AudioUtils.PlaySound("Throwing", pa.clipList, pa.a);
    }

    private void LateUpdate()
    {
        if (i.isAiming)
            spine.rotation = Quaternion.Euler(spine.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 57, spine.rotation.eulerAngles.z);
    }

    public override void PlayerId(RpcArgs args)
    {
        throw new System.NotImplementedException();
    }
}
