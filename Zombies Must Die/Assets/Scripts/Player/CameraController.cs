using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : PlayerBehavior {

	[Range(0.1f, 20)]
	public float rotationSpeedY = 1;
	[Range(0.1f, 20)]
	public float rotationSpeedX = 1;

	public Vector3 distance = new Vector3(0, 1, -5);
	public Vector3 offset = new Vector3(0.8f, 0.8f, 8);
	public Transform Target;
	public float horizontal;
	public float vertical;

    Inputs i;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        i = GameObject.FindGameObjectWithTag("Player").GetComponent<Inputs>();
	}

	void Update () {

        if(Target == null) Target = GameObject.FindGameObjectWithTag("Player").transform;

        vertical -= Input.GetAxis("Mouse Y") * rotationSpeedY;
		horizontal +=  Input.GetAxis("Mouse X") * rotationSpeedX;
		vertical = Mathf.Clamp(vertical, -40, 40);

        Vector3 dir = new Vector3(distance.x, distance.y, -distance.z);
        Quaternion rotation = Quaternion.Euler(vertical, horizontal, 0);

        if (Input.GetButton("Fire2"))
        {
            transform.rotation = rotation;
            transform.position = Target.position + rotation * offset;
            //Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);

        }
        else
        {
            transform.rotation = rotation;
            transform.position = Target.position + rotation * dir;
        }
    }
}
