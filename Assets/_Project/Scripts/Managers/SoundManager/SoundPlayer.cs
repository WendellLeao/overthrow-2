using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSourceProperties[] _audioSourceProperties;
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound3D(Sound sound, Vector3 position)
    {
        SetAudioSourceProperties(sound);
        
        transform.position = position;

        _audioSource.Play();
        
        HandleSoundPlayerDeactivating();
    }

    public void PlaySound2D(Sound sound)
    {
        SetAudioSourceProperties(sound);

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

    private void SetAudioSourceProperties(Sound sound)
    {
        foreach (AudioSourceProperties _audioSourceProperties in _audioSourceProperties)//Dictionary
        {
            if (_audioSourceProperties.Sound == sound)
            {
                int randomIndex = Random.Range(0, _audioSourceProperties.AudioClips.Length);
                _audioSource.clip = _audioSourceProperties.AudioClips[randomIndex];
        
                _audioSource.volume = _audioSourceProperties.Volume;
        
                _audioSource.spatialBlend = _audioSourceProperties.SpatialBlend;
        
                _audioSource.loop = _audioSourceProperties.Loop;
        
                _audioSource.outputAudioMixerGroup = _audioSourceProperties.AudioMixerGroup;
        
                if (_audioSourceProperties.PersistentSound)
                {
                    DontDestroyOnLoad(_audioSource.gameObject);
                }
            }
        }
    }
}
