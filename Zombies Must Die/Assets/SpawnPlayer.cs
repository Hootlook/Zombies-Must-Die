using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : PlayerBehavior
{
    protected override void NetworkStart()
    {
        base.NetworkStart();
        NetworkManager.Instance.InstantiatePlayer();
    }

}
