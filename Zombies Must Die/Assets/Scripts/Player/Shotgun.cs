using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBehavior
{
	public int pellets = 6;
	public float range = 30;
	public GameObject impact;
	public float maximumSpread = 0.3f;
    public float fireTimer;
    public float fireRate;
    PlayerSetup ps;
    Inputs i;
    AudioSource a;
    WeaponBase wb;
    private Vector3 camForward;


    protected override void NetworkStart()
    {
        base.NetworkStart();

        i = GetComponentInParent<Inputs>();
        ps = GetComponentInParent<PlayerSetup>();
        wb = GetComponent<WeaponBase>();
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (networkObject == null) return;

        if (fireTimer < fireRate) fireTimer += Time.fixedDeltaTime;

        camForward = networkObject.IsOwner ? ps.networkObject.cameraAxis : ps.camAxis;

        if (i.isShooting)
		{
            if (fireTimer <= fireRate) return;

            wb.isShooting = true;

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
        
        wb.isShooting = false;
    }
}
