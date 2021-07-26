using System.Collections.Generic;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private AudioSourceProperties[] _audioSourceProperties;

    private Dictionary<Sound, AudioSourceProperties> _audioSourcePropertiesDictionary;
    
    public void PlaySound3D(Sound sound, Vector3 position)
    {
        if (_audioSourcePropertiesDictionary.TryGetValue(sound, out AudioSourceProperties audioSourceProperties))
        {
            GetSoundPlayer().PlaySound3D(audioSourceProperties, position);
        }
    }

    public void PlaySound2D(Sound sound)
    {
        if (_audioSourcePropertiesDictionary.TryGetValue(sound, out AudioSourceProperties audioSourceProperties))
        {
            GetSoundPlayer().PlaySound2D(audioSourceProperties);
        }
    }
    
    private void Awake()
    {
        SetSingleton(this);
    }
    
    private void Start()
    {
        InitializeAudioPropertiesDictionary();
    }
    
    private void InitializeAudioPropertiesDictionary()
    {
        _audioSourcePropertiesDictionary = new Dictionary<Sound, AudioSourceProperties>();
        
        foreach (AudioSourceProperties audioSourceProperties in _audioSourceProperties)
        {
            _audioSourcePropertiesDictionary.Add(audioSourceProperties.Sound, audioSourceProperties);
        }
    }

    private SoundPlayer GetSoundPlayer()
    {
        GameObject soundPlayerGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        SoundPlayer soundPlayer = soundPlayerGameObject.GetComponent<SoundPlayer>();

        return soundPlayer;
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
