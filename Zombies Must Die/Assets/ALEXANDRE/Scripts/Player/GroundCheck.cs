/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	public Vector3 dir;
	public Vector3 origin;
	public float distance = 2;
	public bool isGrounded;
	int layerMask;

    void Start()
    {
		layerMask = 1 << 9;
		layerMask = ~layerMask;
	}

    void Update()
    {
        if(Physics.Raycast(transform.position + origin,transform.position + dir, distance, layerMask))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
    }
}
