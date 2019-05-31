using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : GrenadeBehavior
{
    Rigidbody rb;
    AudioSource a;
    SphereCollider sc;
    public float explosionRadius = 12;
    private int layerMask = 1 << 11;
    public float proximity = 50;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        layerMask = ~layerMask;

        if (this == !enabled) return;

        gameObject.name = "Grenade";
        a = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();

        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
        networkObject.positionInterpolation.target = transform.position;
        networkObject.rotationInterpolation.target = transform.rotation;
        networkObject.SnapInterpolations();

        a.Play();

        if(networkObject.IsOwner)
        networkObject.Destroy(4000);

        FxManager.EmitParticleOnDestroy("WFX_Explosion", transform);
        FxManager.EmitSoundOnDestroy("grenade_explosion", transform, 2);
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

    private void OnDestroy()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);
        foreach (Collider col in objectsInRange)
        {
            if (Physics.Raycast(transform.position, (col.transform.position - transform.position), out RaycastHit hit, explosionRadius, layerMask))
            {
                if (hit.collider.tag == "Player")
                {
                    float distance = Vector3.Distance(hit.collider.transform.position, transform.position);
                    proximity /= distance;

                    EZCameraShake.CameraShaker.Instance.ShakeOnce(5, proximity, 0, 1);
                }
            }
        }
    }
}
