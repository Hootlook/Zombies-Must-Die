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

    private void Update()
    {
        if (networkObject == null) return;

        if (networkObject.IsOwner)
        {
            networkObject.isArmed = isArmed;
        }
        else
        {
            isArmed = networkObject.isArmed;
        }
    }
}
