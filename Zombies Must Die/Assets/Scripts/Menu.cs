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
        
    }

    protected override void NetworkStart()
    {
        base.NetworkStart();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
        cc = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) menuState = !menuState;

        menu.SetActive(menuState);

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
