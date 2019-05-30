using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : GrenadeBehavior
{
    Rigidbody rb;
    AudioSource a;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (this == !enabled) return;

        gameObject.name = "Grenade";
        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
        networkObject.positionInterpolation.target = transform.position;
        networkObject.rotationInterpolation.target = transform.rotation;
        networkObject.SnapInterpolations();

        a.Play();

        if(networkObject.IsOwner)
        networkObject.Destroy(5000);

        FxManager.EmitSound("grenade_explosion", 5, transform, 1, 10);
        FxManager.EmitParticle("WFX_Explosion", 5, transform);
    }

    private void OnDestroy()
    {
        //if(transform.GetComponent<CapsuleCollider>().isTrigger)
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
