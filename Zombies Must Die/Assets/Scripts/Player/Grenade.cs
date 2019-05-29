using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : GrenadeBehavior
{
    Rigidbody rb;
    AudioSource a;
    public float counter = 0;
    public float timer = 1;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        gameObject.name = "Grenade";
        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
        networkObject.positionInterpolation.target = transform.position;
        networkObject.rotationInterpolation.target = transform.rotation;
        networkObject.SnapInterpolations();

        if (transform.parent == null)
        {
            a.Play();
            networkObject.Destroy(5000);
        }
    }

    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
        }
    }
}
