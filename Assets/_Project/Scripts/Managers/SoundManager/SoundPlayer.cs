using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound3D(AudioSourceProperties audioSourceProperties, Vector3 position)
    {
        SetAudioSourceProperties(audioSourceProperties);
        
        transform.position = position;

        _audioSource.Play();
        
        HandleSoundPlayerDeactivating();
    }

    public void PlaySound2D(AudioSourceProperties audioSourceProperties)
    {
        SetAudioSourceProperties(audioSourceProperties);

        _audioSource.PlayOneShot(_audioSource.clip);
        
        HandleSoundPlayerDeactivating();
    }

    private void OnDisable()
    {
        ObjectPool.instance.ReturnObjectToPool(PoolType.SOUND_PLAYER, this.gameObject);
    }
    
    private void HandleSoundPlayerDeactivating()
    {
        if (!_audioSource.loop)
        {
            StartCoroutine(DeactivateSoundGameObject());
        }
    }
    
    private IEnumerator DeactivateSoundGameObject()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        
        this.gameObject.SetActive(false);
    }

    private void SetAudioSourceProperties(AudioSourceProperties audioSourceProperties)
    {
        int randomIndex = Random.Range(0, audioSourceProperties.AudioClips.Length);
        _audioSource.clip = audioSourceProperties.AudioClips[randomIndex];
        
        _audioSource.volume = audioSourceProperties.Volume;
        
        _audioSource.spatialBlend = audioSourceProperties.SpatialBlend;
        
        _audioSource.loop = audioSourceProperties.Loop;
        
        _audioSource.outputAudioMixerGroup = audioSourceProperties.AudioMixerGroup;
        
        if (audioSourceProperties.PersistentSound)
        {
            DontDestroyOnLoad(_audioSource.gameObject);
        }
    }
}
