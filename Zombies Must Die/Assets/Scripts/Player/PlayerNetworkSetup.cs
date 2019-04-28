using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public class PlayerNetworkSetup : PlayerBehavior
{
    public GameObject camera;
    public bool isGrounded;
    public float vertical;
    PlayerMovements pm;
    CharacterController cc;
    CameraController cameraController;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (networkObject.IsOwner)
        {
            gameObject.tag = "Player";
            Instantiate(camera);
        }
        cc = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovements>();

    }
   
    void Update()
    {
        if (networkObject != null)
        {
            cameraController = GameObject.Find("Camera(Clone)").GetComponent<CameraController>();
            if (networkObject.IsOwner)
            {
                networkObject.position = transform.position;
                networkObject.rotation = transform.rotation;
                networkObject.spine = pm.spine.rotation;
                networkObject.isGrounded = cc.isGrounded;
                networkObject.cameraVertical = cameraController.vertical;
            }
            else
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
                pm.spine.rotation = networkObject.spine;
                isGrounded = networkObject.isGrounded;
                vertical = networkObject.cameraVertical;
            }
        }        
    }
}
