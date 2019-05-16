using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : PlayerBehavior
{
	[SerializeField]
	GameObject menu;
	Inputs i;
	CameraController cc;
	bool menuState;


	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
		PlayerSetup.PlayerLoaded += playerInstantiated;
		gameObject.SetActive(false);
	}

	private void playerInstantiated()
	{
		i = GameObject.FindWithTag("Player").GetComponent<Inputs>();
		cc = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Cancel")) menuState = !menuState;

		menu.SetActive(menuState);

		if (menu.activeSelf == true)
		{
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			i.enabled = false;
			cc.enabled = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			i.enabled = true;
			cc.enabled = true;
		}
	}

	private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		if (arg0.name == "MainMenu")
		{
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
		}
	}

	public void Disconnect()
	{
		NetworkManager.Instance.Disconnect();
		SceneManager.LoadScene(0);
	}

}


