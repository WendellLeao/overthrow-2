using System.Collections.Generic;
using _Project.Scripts.Enums.Managers.SoundManager;
using _Project.Scripts.Enums.ObjectPool;
using UnityEngine;

namespace _Project.Scripts.Managers.SoundManager
{
    public sealed class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
    
        [SerializeField] private AudioSourceProperties[] _audioSourceProperties;

        private Dictionary<Sound, AudioSourceProperties> _audioSourcePropertiesDictionary;
    
        public void PlaySound3D(Sound sound, Vector3 position)
        {
            if (_audioSourcePropertiesDictionary.TryGetValue(sound, out AudioSourceProperties audioSourceProperties))
            {
                if (CanPlaySound(audioSourceProperties))
                {
                    GetSoundPlayer().PlaySound3D(audioSourceProperties, position);

                    audioSourceProperties.IsPlaying = true;
                }
            }
        }

        public void PlaySound2D(Sound sound)
        {
            if (_audioSourcePropertiesDictionary.TryGetValue(sound, out AudioSourceProperties audioSourceProperties))
            {
                if (CanPlaySound(audioSourceProperties))
                {
                    GetSoundPlayer().PlaySound2D(audioSourceProperties);
                
                    audioSourceProperties.IsPlaying = true;
                }
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

        private bool CanPlaySound(AudioSourceProperties audioSourceProperties)
        {
            return !audioSourceProperties.PersistentSound || !audioSourceProperties.IsPlaying;
        }

        private SoundPlayer GetSoundPlayer()
        {
            GameObject soundPlayerGameObject = ObjectPool.ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        
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
}
