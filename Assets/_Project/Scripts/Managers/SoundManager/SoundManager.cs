using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public void PlaySound3D(Sound sound, Vector3 position)
    {
        GameObject soundPlayerGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        SoundPlayer soundPlayer = soundPlayerGameObject.GetComponent<SoundPlayer>();

        soundPlayer.PlaySound3D(sound, position);
    }

    public void PlaySound2D(Sound sound)
    {
        GameObject soundPlayerGameObject = ObjectPool.instance.GetObjectFromPool(PoolType.SOUND_PLAYER);
        SoundPlayer soundPlayer = soundPlayerGameObject.GetComponent<SoundPlayer>();

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
