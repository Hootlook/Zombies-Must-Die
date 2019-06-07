using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : EntityBehavior, IEntityBase
{
    public GameObject spawer;

    public void OnInteract(Transform from)
    {
        NetworkManager.Instance.InstantiateWeapon(index: 1, position: spawer.transform.position, rotation: spawer.transform.rotation);
    }
}
