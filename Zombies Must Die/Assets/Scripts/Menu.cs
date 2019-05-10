using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : PlayerBehavior
{
    [SerializeField]
    GameObject menu;
    PlayerMovements pm;
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
		pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
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
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == "MainMenu")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
