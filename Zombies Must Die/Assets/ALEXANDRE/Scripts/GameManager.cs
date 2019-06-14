/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject menu;
    public GameObject fxManager;
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
        Instantiate(fxManager);
    }

}
