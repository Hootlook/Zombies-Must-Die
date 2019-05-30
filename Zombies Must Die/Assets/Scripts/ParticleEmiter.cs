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
        if (counter <= timer) counter += Time.deltaTime;

        if (counter >= timer) transform.GetChild(0).gameObject.SetActive(true);

        if (!p.isPlaying && counter >= timer) Destroy(gameObject);

        if (target == null) return;
        transform.position = target.position;
    }
}
