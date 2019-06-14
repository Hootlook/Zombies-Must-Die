/************************************
 *  Class made by Alexandre Doukhan
 ************************************/

using System.Collections.Generic;
using UnityEngine;

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
    
    public static void EmitSoundOnDestroy(string clipName, Transform followTarget = null, float minDistance = 1)
    {
        GameObject emiter = new GameObject("AudioEmiter", typeof(SoundEmiter), typeof(AudioSource));
        AudioSource emitersAudioSource = emiter.GetComponent<AudioSource>();

        emiter.GetComponent<SoundEmiter>().target = followTarget;

        emitersAudioSource.playOnAwake = false;
        emitersAudioSource.spatialBlend = 1;
        emitersAudioSource.minDistance = minDistance;

        foreach (AudioClip c in _instance.clips)
        {
            if (c.name == clipName)
            {
                emitersAudioSource.clip = c;
            }
        }
    }

    public static void EmitParticleOnDestroy(string particleObjectName, Transform followTarget = null)
    {
        GameObject emiter = new GameObject("ParticleEmiter", typeof(ParticleEmiter));
        ParticleEmiter emitersParticleEmiter = emiter.GetComponent<ParticleEmiter>();

        emitersParticleEmiter.target = followTarget;

        foreach (GameObject g in _instance.particlesObjects)
        {
            if (g.name == particleObjectName)
            {
                Instantiate(g, emiter.transform);
            }
        }
    }
}
