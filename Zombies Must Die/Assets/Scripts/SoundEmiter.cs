using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmiter : MonoBehaviour
{
    AudioSource a;
    public Transform target;
    private bool onetime = false;

    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (a.clip == null) return;

        if(target == null)
        {
            if (!onetime)
            {
                a.Play();
                onetime = true;
            }

            if (!a.isPlaying) Destroy(gameObject);
        }
        else
        {
            transform.position = target.position;
        }
    }
}
