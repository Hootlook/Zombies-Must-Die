using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : WeaponBehavior, IEntityBase
{
    public int id;
    public bool isShooting;
    public bool isReloading;
    public bool isArmed;
    public bool isEquipped;

    public Inputs i;
    public AudioSource a;
    public Rigidbody rb;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
        networkObject.positionInterpolation.target = transform.position;
        networkObject.rotationInterpolation.target = transform.rotation;
        networkObject.SnapInterpolations();
    }

    public void OnInteract(int player)
    {
        networkObject.SendRpc(RPC_EQUIP_WEAPON, Receivers.All, player);
    }

    protected void Update()
    {
        if (networkObject == null) return;

        if (transform.parent == null)
        {
            if (networkObject.IsOwner)
            {
                networkObject.position = transform.position;
                networkObject.rotation = transform.rotation;
            }
            else
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
            }
        }

        if (networkObject.IsOwner)
        {
            networkObject.isEquipped = isEquipped;
            networkObject.isArmed = isArmed;
        }
        else
        {
            isEquipped = networkObject.isEquipped;
            isArmed = networkObject.isArmed;
        }
    }

    public override void EquipWeapon(RpcArgs args)
    {
        transform.SetParent(GameObject.Find("Player " + args.GetNext<int>()).GetComponent<WeaponManager>().weaponBone);
        i = GetComponentInParent<Inputs>();
        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        isEquipped = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
