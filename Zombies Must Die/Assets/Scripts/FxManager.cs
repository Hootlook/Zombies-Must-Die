using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FxManager : MonoBehaviour
{
    public List<AudioClip> clips;
    public List<GameObject> particlesObjects;
    static FxManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("There is already a FxManager, the new one got destroyed");
            Destroy(gameObject);
        }
    }
    
    public static void EmitSound(string clipName, float delay = 0, Transform followTarget = null, float spacialBlend = 1, float minDistance = 1)
    {
        GameObject emiter = new GameObject("AudioEmiter", typeof(AudioSource), typeof(SoundEmiter));
        AudioSource emitersAudioSource = emiter.GetComponent<AudioSource>();

        if (followTarget != null) emiter.GetComponent<SoundEmiter>().target = followTarget;

        emitersAudioSource.spatialBlend = spacialBlend;
        emitersAudioSource.minDistance = minDistance;

        foreach (AudioClip c in _instance.clips)
        {
            if (c.name == clipName)
            {
                emitersAudioSource.clip = c;
                if (delay == 0)
                    emitersAudioSource.Play();
                else
                    emitersAudioSource.PlayDelayed(delay);
            }
        }
    }

    public static void EmitParticle(string particleObjectName, float delay = 0, Transform followTarget = null)
    {
        GameObject emiter = new GameObject("ParticleEmiter", typeof(ParticleEmiter));
        ParticleEmiter emitersParticleEmiter = emiter.GetComponent<ParticleEmiter>();

        if (followTarget != null) emitersParticleEmiter.target = followTarget;

        emitersParticleEmiter.timer = delay;

        foreach (GameObject g in _instance.particlesObjects)
        {
            if (g.name == particleObjectName)
            {
                Instantiate(g, emiter.transform);
            }
        }
    }

}
