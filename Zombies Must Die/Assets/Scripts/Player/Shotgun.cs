using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : PlayerBehavior
{
	public int pellets = 6;
	public float range = 30;
	[SerializeField]
	GameObject impact;
	public float maximumSpread = 0.3f;
    public float fireTimer;
    public float fireRate;
    Inputs i;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        i = GetComponentInParent<Inputs>();
    }

    void Update()
    {
        if (fireTimer < fireRate) { fireTimer += Time.fixedDeltaTime; }

        RaycastHit hit;

		if (i.isShooting)
		{
			for (int i = 0; i < pellets; i++)
			{
				//Get horizontal and vertical spread.
				float spreadX = Random.Range(-maximumSpread, maximumSpread);
				float spreadY = Random.Range(-maximumSpread, maximumSpread);
				//Don't adjust depth of spread.
				float spreadZ = 0f;
				//Make spread converting from local space to world space.
				Vector3 spread = Camera.main.transform.TransformDirection(new Vector3(spreadX, spreadY, spreadZ));
				Vector3 direction = (Camera.main.transform.forward + spread).normalized;
				//Vector3 direction = Random.insideUnitCircle * spread;  THE OLD WAY
				if (Physics.Raycast(transform.position, Camera.main.transform.forward + direction, out hit, range))
				{
					Debug.Log(hit.transform.name);
					Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
				}
			}
		}

    }
}
