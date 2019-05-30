using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmiter : MonoBehaviour
{
    AudioSource a;
    public Transform target;

    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!a.isPlaying) Destroy(gameObject);

        if (target == null) return;
        transform.position = target.position;
    }
}
