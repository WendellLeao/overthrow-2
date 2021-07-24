using System.Collections;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private AudioSourceProperties[] _audioSourceProperties;
    
    public void PlaySound3D(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND);

        soundGameObject.transform.position = position;
        
        AudioSource audioSource = GetSettedAudioSource(sound, soundGameObject);

        if (!audioSource.loop)
        {
            StartCoroutine(DeactivateSoundGameObject(audioSource));
        }

        audioSource.Play();
    }

    public void PlaySound2D(Sound sound)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND);
        
        AudioSource audioSource = GetSettedAudioSource(sound, soundGameObject);
        
        if (!audioSource.loop)
        {
            StartCoroutine(DeactivateSoundGameObject(audioSource));
        }

        audioSource.PlayOneShot(audioSource.clip);
    }
    
    private void Awake()
    {
        SetSingleton(this);
    }

    private IEnumerator DeactivateSoundGameObject(AudioSource audioSource)
    {
        GameObject soundGameObject = audioSource.gameObject;

        yield return new WaitForSeconds(audioSource.clip.length);

        ObjectPool.instance.ReturnObjectToPool(PoolType.SOUND, soundGameObject);
    }
    
    private AudioSource GetSettedAudioSource(Sound sound, GameObject soundGameObject)
    {
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();
        
        foreach(AudioSourceProperties audioSourceProperties in _audioSourceProperties)
        {
            if (audioSourceProperties.Sound == sound)
            {
                int randomIndex = Random.Range(0, audioSourceProperties.AudioClips.Length);
                audioSource.clip = audioSourceProperties.AudioClips[randomIndex];
        
                audioSource.volume = audioSourceProperties.Volume;
        
                audioSource.spatialBlend = audioSourceProperties.SpatialBlend;
        
                audioSource.loop = audioSourceProperties.Loop;
        
                audioSource.outputAudioMixerGroup = audioSourceProperties.AudioMixerGroup;
        
                if (audioSourceProperties.PersistentSound)
                {
                    DontDestroyOnLoad(audioSource.gameObject);
                }
            }
        }
        
        return audioSource;
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
