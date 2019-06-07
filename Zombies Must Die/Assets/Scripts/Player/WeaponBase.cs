using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : WeaponBehavior
{
    public int id;
    public bool isShooting;
    public bool isReloading;
    public bool isArmed;
    public bool isEquipped;

    private void Update()
    {
        if (networkObject == null) return;

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
}
