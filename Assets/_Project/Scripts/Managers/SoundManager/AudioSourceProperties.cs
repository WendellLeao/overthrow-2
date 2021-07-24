using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Manager/Audio Source Properties")]
public sealed class AudioSourceProperties : ScriptableObject
{  
    public Sound Sound;
    
    public AudioClip[] AudioClips;
    
    public AudioMixerGroup AudioMixerGroup;

    [Range(0f, 1f)]
    public float Volume;
    
    [Range(0f, 1f)]
    public float SpatialBlend;

    public bool PersistentSound;
    
    public bool Loop;
}
