/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using UnityEngine;

public class Shotgun : WeaponBase
{
	public int pellets = 6;
	public float range = 30;
	public GameObject impact;
	public float maximumSpread = 0.3f;
    public float fireTimer;
    public float fireRate;
    PlayerSetup ps;
    private Vector3 camForward;


    protected override void NetworkStart()
    {
        base.NetworkStart();

        ps = GetComponentInParent<PlayerSetup>();
    }

    new void Update()
    {
        base.Update();
        if (networkObject == null) return;

        if (fireTimer < fireRate) fireTimer += Time.fixedDeltaTime;

        camForward = networkObject.IsOwner ? ps.networkObject.cameraAxis : ps.camAxis;

        if (i.isShooting)
		{
            if (fireTimer <= fireRate) return;

            isShooting = true;

			for (int i = 0; i < pellets; i++)
			{
                Random.InitState(i);
				float spreadX = Random.Range(-maximumSpread, maximumSpread);
				float spreadY = Random.Range(-maximumSpread, maximumSpread);
				float spreadZ = 0f; //Don't adjust depth of spread.

                Vector3 spread = transform.TransformDirection(new Vector3(spreadX, spreadY, spreadZ));
				Vector3 direction = (camForward + spread).normalized;

                if (Physics.Raycast(transform.position, camForward + direction, out RaycastHit hit, range))
                {
                    //Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                }

                if (networkObject.IsOwner)
                EZCameraShake.CameraShaker.Instance.ShakeOnce(1, 5, 0, 1);
			}
            a.Play();

            fireTimer = 0;
        }
        
        isShooting = false;
    }
}
