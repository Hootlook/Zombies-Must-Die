using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmiter : MonoBehaviour
{
    ParticleSystem p;
    public Transform target;
    public float counter = 0;
    public float timer;

    void Start()
    {
        p = GetComponentInChildren<ParticleSystem>(true);
    }

    void Update()
    {
        if(target == null) transform.GetChild(0).gameObject.SetActive(true);
        else transform.position = target.position;

        if (!p.isPlaying && target == null) Destroy(gameObject);
    }
}
