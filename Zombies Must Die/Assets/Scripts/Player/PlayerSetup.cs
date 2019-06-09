using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : PlayerBehavior
{
    public GameObject cam;
    public bool isGrounded;
    public float vertical;
    public Vector3 camAxis;
    public int selectedWeapon;
    PlayerMovements pm;
    PlayerAnimations pa;
    CharacterController cc;
    public CameraController cameraController;
    WeaponManager wm;
    public Text nameLabel;
    public GameObject playerTitle;

    public uint playerID = 0;


    public delegate void playerInstance();
	public static event playerInstance PlayerLoaded;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        GameMode gameMode = GameObject.Find("GameMode").GetComponent<GameMode>();

        if (networkObject.IsOwner)
        {
            gameObject.tag = "Player";
            Instantiate(cam);
        }
        cc = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovements>();
        pa = GetComponent<PlayerAnimations>();
        wm = GetComponent<WeaponManager>();
        cameraController = GameObject.Find("Camera(Clone)").GetComponent<CameraController>();

        PlayerLoaded();
    }

    public override void PlayerID(RpcArgs args)
    {
        playerID = args.GetNext<uint>();

        gameObject.name = "Player " + playerID;
        nameLabel.text = "Player " + playerID;
    }

    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(playerTitle.transform.position);
        nameLabel.transform.position = namePos;

        if (networkObject != null)
        {
            if (networkObject.IsOwner)
            {
                networkObject.position = transform.position;
                networkObject.rotation = transform.rotation;
                networkObject.spine = pa.spine.rotation;
                networkObject.isGrounded = cc.isGrounded;
                networkObject.selectedWeapon = wm.selectedWeapon;
                networkObject.cameraVertical = cameraController.vertical;
                networkObject.cameraAxis = Camera.main.transform.forward;
            }
            else
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
                pa.spine.rotation = networkObject.spine;
                isGrounded = networkObject.isGrounded;
                vertical = networkObject.cameraVertical;
                camAxis = networkObject.cameraAxis;
                selectedWeapon = networkObject.selectedWeapon;
            }
        }        
    }


}
