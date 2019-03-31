using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator a;

    void Start()
    {
        a = GetComponent<Animator>();
    }

    void Update()
    {
        a.SetFloat("Vertical", Input.GetAxis("Vertical"));
        a.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		a.SetBool("Aiming", Input.GetButton("Fire2"));
    }
}
