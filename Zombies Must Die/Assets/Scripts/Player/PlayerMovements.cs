using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    CharacterController cc;
    Transform cameraHolder;
    public float speed = 1;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        cc.Move(inputs);

        if (!cc.isGrounded)
        {
            cc.Move((Vector3.up * Physics.gravity.y) * Time.deltaTime);
        }
    }
}
