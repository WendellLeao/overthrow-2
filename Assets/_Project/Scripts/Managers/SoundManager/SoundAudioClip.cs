using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Sound Manager/Sound Audio Clip")]
public sealed class SoundAudioClip : ScriptableObject
{  
    public Sound Sound;
    
    public AudioClip AudioClip;
    
    public AudioMixerGroup AudioMixerGroup;

    public float Volume;
    
    public float SpatialBlend;
    
    public bool Loop;
}
