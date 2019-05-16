using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject menu;
	private static GameManager _instance;

	private void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(_instance != this)
		{
			Destroy(gameObject);
			return;
		}
	}

	private void Start()
    {
		Instantiate(menu);
    }

}
