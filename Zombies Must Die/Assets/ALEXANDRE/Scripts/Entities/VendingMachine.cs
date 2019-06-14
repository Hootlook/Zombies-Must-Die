/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using UnityEngine;

public class VendingMachine : EntityBehavior, IEntityBase
{
    public GameObject spawer;
    public int weaponChoice = 1;

    public void OnInteract(int player)
    {
        NetworkManager.Instance.InstantiateWeapon(index: weaponChoice, position: spawer.transform.position, rotation: spawer.transform.rotation);
    }
}
