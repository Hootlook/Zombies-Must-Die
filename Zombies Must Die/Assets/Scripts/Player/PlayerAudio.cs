using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public List<AudioClip> clips;
    AudioSource a;

    private void Start()
    {
        a = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        foreach (AudioClip c in clips)
        {
            if(c.name == clip)
            {
                a.PlayOneShot(c);
            }
        }
    }
}
