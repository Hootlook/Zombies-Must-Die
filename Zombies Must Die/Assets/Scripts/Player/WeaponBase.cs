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
    public WeaponBase wb;

    public void OnInteract(Transform from)
    {
        EquipWeapon(from);
    }

    public void EquipWeapon(Transform from)
    {
        transform.SetParent(from.GetComponent<WeaponManager>().weaponBone);
        i = GetComponentInParent<Inputs>();
        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        wb = GetComponent<WeaponBase>();
        rb.isKinematic = true;
        wb.isEquipped = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        if (networkObject == null) return;

        if (networkObject.IsOwner)
        {
            networkObject.isEquipped = isEquipped;
            networkObject.isArmed = isArmed;
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
        else
        {
            isEquipped = networkObject.isEquipped;
            isArmed = networkObject.isArmed;
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
        }
    }
}
