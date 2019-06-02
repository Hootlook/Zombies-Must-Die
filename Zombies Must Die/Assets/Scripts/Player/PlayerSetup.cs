using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

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
	public delegate void playerInstance();
	public static event playerInstance PlayerLoaded;

	protected override void NetworkStart()
    {
        base.NetworkStart();

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
   
    void Update()
    {
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
