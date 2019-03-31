using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
	public int pellets = 6;
	public float range = 30;
	[SerializeField]
	GameObject impact;
	public float spread = 0.3f;

	void Start()
    {
        
    }

    void Update()
    {
		RaycastHit hit;

		if (Input.GetButtonDown("Fire1"))
		{
			for (int i = 0; i < pellets; i++)
			{
				Vector3 direction = Random.insideUnitCircle * spread;
				if (Physics.Raycast(transform.position, Camera.main.transform.forward + direction, out hit, range))
				{
					Debug.Log(hit.transform.name);
					Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
				}
			}
		}

    }
}
