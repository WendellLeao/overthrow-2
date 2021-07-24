using System.Collections;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private SoundAudioClip[] _soundAudioClips;
    
    public GameObject PlaySound3D(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND);
        
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();

        soundGameObject.transform.position = position;

        SetSoundProperties(sound, audioSource);

        audioSource.Play();

        StartCoroutine(DeactivateSoundGameObject(audioSource, soundGameObject));

        return soundGameObject;
    }
    
    public void PlayPersistentSound3D(Sound sound, Vector3 position)
    {
        DontDestroyOnLoad(PlaySound3D(sound, position));
    }
    
    public GameObject PlaySound2D(Sound sound)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND);
        
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();

        SetSoundProperties(sound, audioSource);
        
        audioSource.PlayOneShot(audioSource.clip);

        StartCoroutine(DeactivateSoundGameObject(audioSource, soundGameObject));

        return soundGameObject;
    }

    public void PlayPersistentSound2D(Sound sound)
    {
        DontDestroyOnLoad(PlaySound2D(sound));
    }

    private void Awake()
    {
        SetSingleton(this);
    }
    
    private IEnumerator DeactivateSoundGameObject(AudioSource audioSource, GameObject soundGameObject)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        
        soundGameObject.SetActive(false);
        
        ObjectPool.instance.ReturnObjectToPool(PoolType.SOUND, soundGameObject);
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
    
    private void SetSoundProperties(Sound sound, AudioSource audioSource)
    {
        foreach(SoundAudioClip soundAudioClip in _soundAudioClips)
        {
            if (soundAudioClip.Sound == sound)
            {
                audioSource.clip = soundAudioClip.AudioClip;

                audioSource.volume = soundAudioClip.Volume;

                audioSource.spatialBlend = soundAudioClip.SpatialBlend;

                audioSource.loop = soundAudioClip.Loop;

                audioSource.outputAudioMixerGroup = soundAudioClip.AudioMixerGroup;
            }
        }
    }
}
