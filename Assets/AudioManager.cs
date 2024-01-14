using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup soundMixerGroup;

    public AudioMixer audioMixer;

    public static AudioManager instance;

    public void PlayClipAt(AudioClip clip)
    {
        AudioSource tmpAudioClip = new GameObject("tmp Audio Go").AddComponent<AudioSource>();
        tmpAudioClip.outputAudioMixerGroup = soundMixerGroup;
        tmpAudioClip.clip = clip;
        tmpAudioClip.Play();
        Destroy(tmpAudioClip.gameObject, clip.length);
    }
}