using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtils : MonoBehaviour
{
    public static void PlaySound(string clipName, List<AudioClip> audioClips, AudioSource audioSource)
    {
        foreach (AudioClip c in audioClips)
        {
            if (c.name == clipName)
            {
                audioSource.PlayOneShot(c);
            }
        }
    }
}
