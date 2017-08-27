using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager 
{
    public Facade facade;
    private const string Sound_Prefix = "Sounds/";

    public const string Sound_StartBGM = "StartBGM";
    public const string Sound_DailyBGM = "DailyBGM";

    public const string Sound_FightBGM = "FightBGM";

    public const string Sound_People = "People";
    public const string Sound_Tiger = "Tiger";
    public const string Sound_Win = "Win";
    public const string Sound_Warning = "Warning";
    public const string Sound_Error = "Error";
    public const string Sound_GetSomething = "GetSomething";
    public const string Sound_OnClick = "OnClick";

    private AudioSource bgAudioSource;
    private AudioSource normalAudioSource;

    public AudioManager(Facade facade)
    {
        this.facade = facade;
    }

    public void OnInit()
    {
        GameObject audioSourceGO = new GameObject("AudioSource(GameObject)");

        bgAudioSource = audioSourceGO.AddComponent<AudioSource>();
        normalAudioSource = audioSourceGO.AddComponent<AudioSource>();

        PlaySound(bgAudioSource, LoadSound(Sound_DailyBGM), 0.5f, true);

    }

    public void PlayBgSound(string soundName)
    {
        PlaySound(bgAudioSource, LoadSound(soundName), 0.5f, true);
    }

    public void PlayNormalSound(string soundName)
    {
        PlaySound(normalAudioSource, LoadSound(soundName), 1f);
    }

    private void PlaySound(AudioSource audioSource, AudioClip clip, float volume, bool loop = false)
    {

        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.Play();
    }
    private AudioClip LoadSound(string soundsName)
    {
        return Resources.Load<AudioClip>(Sound_Prefix + soundsName);
    }
}
