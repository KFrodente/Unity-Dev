using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    

    public void PlayClip(AudioClip clip)
    {
        source.pitch = 1;
        source.PlayOneShot(clip);
    }

    public void PlayClipAtPitch(AudioClip clip, float pitch)
    {
        source.pitch = pitch;
        source.PlayOneShot(clip);
    }

    public void PlayClipRandomPitch(AudioClip clip)
    {
        source.pitch = Random.Range(.7f, 1.5f);
        source.PlayOneShot(clip);
    }
}
