using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public float volumeVariance;
    public float pitchVariance;
    public float fadeOutDuration;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
