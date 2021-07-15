using UnityEngine.Audio;
using UnityEngine;
using System;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    [SerializeField] private Sound[] _sounds;

    private bool _isPlayingSoundtrack = false;

    private void Awake()
    {
        SetSingleton(this);
        
        SetSoundProperties();
    }

    public void Play(string soundName)///////// Change to enum
    {
        Sound sound = Array.Find(_sounds, sound => sound.name == soundName);
        
        if(sound == null)
        {
            Debug.LogWarning("Sound" + soundName + " not found!");
            
            return;
        }

        sound.source.Play();
    }

    public void StopPlaying(string nameSound)
    {
        Sound sound = Array.Find(_sounds, item => item.name == nameSound);
       
        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            
            return;
        }

        sound.source.Stop();
    }

    public void PlaySoundtrack()
    {
        if(!_isPlayingSoundtrack)
        {
            Play("Soundtrack");

            _isPlayingSoundtrack = true;
        }
    }

    private void SetSingleton(SoundManager soundManager)
    {
        if(instance == null)
        {
            instance = soundManager;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void SetSoundProperties()
    {
        foreach(Sound soundObject in _sounds)
        {
            soundObject.source = gameObject.AddComponent<AudioSource>();

            soundObject.source.clip = soundObject.clip;

            soundObject.source.volume = soundObject.volume;
            soundObject.source.pitch = soundObject.pitch;

            soundObject.source.loop = soundObject.loop;
            
            soundObject.source.outputAudioMixerGroup = _mixerGroup;
        }
    }
}