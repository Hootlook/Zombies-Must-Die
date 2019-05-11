using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PlayerBehavior
{
	public GameObject menu;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
		Instantiate(menu);
    }

    protected override void NetworkStart()
    {
        base.NetworkStart();
        NetworkManager.Instance.InstantiatePlayer();
    }
}
