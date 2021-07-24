using System;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private SoundAudioClip[] _soundAudioClips;
    
    public void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        
        audioSource.PlayOneShot(GetAudioClip(sound));
        
        DontDestroyOnLoad(soundGameObject);///////////////
    }

    private void Awake()///
    {
        SetSingleton(this);
    }
    
    private AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in _soundAudioClips)
        {
            if (soundAudioClip.Sound == sound)
            {
                return soundAudioClip.AudioClip;
            }
        }

        Debug.LogError("Sound " + sound + " not found!");
        return null;
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
}
