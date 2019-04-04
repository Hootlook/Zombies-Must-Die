using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator a;
	CharacterController cc;

    void Start()
    {
        a = GetComponent<Animator>();
		cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        a.SetFloat("Vertical", Input.GetAxis("Vertical"));
        a.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

		if (cc.isGrounded)
		{
			a.SetBool("Aiming", Input.GetButton("Fire2"));
		}
		
    }
}
