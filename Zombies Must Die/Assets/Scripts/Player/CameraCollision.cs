using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

	public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public float distance;
	int layerMask;

	void Awake()
	{
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
		layerMask = 1 << 9;
		layerMask = ~layerMask;
	}

	void Update()
	{
		Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
		RaycastHit hit;

		if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit, layerMask))
		{
			distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);

		}
		else
		{
			distance = maxDistance;
		}
        Debug.DrawLine(transform.parent.position, desiredCameraPos, Color.red);

		transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
