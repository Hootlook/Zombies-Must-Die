using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource a;
    public List<AudioClip> clipList;

    private void Start()
    {
        a = GetComponent<AudioSource>();
    }
}
