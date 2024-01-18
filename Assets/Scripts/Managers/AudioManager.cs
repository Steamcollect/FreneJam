using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    int currentMusicIndex;
    AudioSource audioSource;

    public AudioMixerGroup soundMixerGroup;

    public AudioMixer audioMixer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentMusicIndex = 0;
        audioSource.clip = playlist[currentMusicIndex];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentMusicIndex = (currentMusicIndex + 1) % playlist.Length;
            audioSource.clip = playlist[currentMusicIndex];
            audioSource.Play();
        }
    }

    public void PlayClipAt(Vector2 pos ,AudioClip clip)
    {
        AudioSource tmpAudioClip = new GameObject("tmp Audio Go").AddComponent<AudioSource>();
        tmpAudioClip.transform.position = pos;
        tmpAudioClip.spatialBlend = 1;
        tmpAudioClip.outputAudioMixerGroup = soundMixerGroup;
        tmpAudioClip.clip = clip;
        tmpAudioClip.Play();
        Destroy(tmpAudioClip.gameObject, clip.length);
    }
}