using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    [SerializeField] private AudioSourceProperties[] _audioSourceProperties;
    
    public void PlaySound3D(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        SoundPlayer soundPlayer = soundGameObject.GetComponent<SoundPlayer>();

        soundPlayer.PlaySound3D(sound, position);
    }

    public void PlaySound2D(Sound sound)
    {
        GameObject soundGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        SoundPlayer soundPlayer = soundGameObject.GetComponent<SoundPlayer>();

        soundPlayer.PlaySound2D(sound);
    }
    
    private void Awake()
    {
        SetSingleton(this);
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
