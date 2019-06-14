/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using UnityEngine;

public class CameraCollision : MonoBehaviour
{

	public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public float distance;
	int layerMask;

    public float adjust = 1;

	void Awake()
	{
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
		layerMask = 1 << 2;
		layerMask = ~layerMask;
	}

	void Update()
	{
		Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
		RaycastHit hit;

        adjust = Input.GetButton("Fire2") ? -2 : 1;

		if (Physics.Linecast(transform.parent.position + (Camera.main.transform.forward * adjust), desiredCameraPos, out hit, layerMask))
		{
			distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
		}
		else
		{
			distance = maxDistance;
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
