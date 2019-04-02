using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[Range(1, 20)]
	public float rotationSpeedY = 1;
	[Range(1, 20)]
	public float rotationSpeedX = 1;

	public Vector3 distance = new Vector3(0, 0, 0.1f);
	public Vector3 offset;
	public Transform Target;
	public float distanceY,distanceX;
	public float horizontal = 10f;
	public float vertical = 10f;
	public float shoulderZ;


	void Start ()
	{
		Target = GameObject.FindWithTag("Player").transform;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
	
		vertical -= Input.GetAxis("Mouse Y") * rotationSpeedY;
		horizontal +=  Input.GetAxis("Mouse X") * rotationSpeedX;
		vertical = Mathf.Clamp(vertical, -70, 70);
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3(distance.x, distance.y, -distance.z);
		Quaternion rotation = Quaternion.Euler(vertical, horizontal, 0);	

		if (Input.GetButton("Fire2"))
		{
			transform.rotation = rotation;
			transform.position = Target.position + rotation * offset;
			
		}
		else
		{
			transform.rotation = rotation;
			transform.position = Target.position + rotation * dir;
		}

	}

}
