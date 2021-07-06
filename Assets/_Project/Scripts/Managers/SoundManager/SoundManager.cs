using System;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
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
        foreach(Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }
}