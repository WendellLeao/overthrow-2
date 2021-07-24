using UnityEngine;

[CreateAssetMenu(menuName = "Sound Manager/Sound Audio Clip")]
public sealed class SoundAudioClip : ScriptableObject
{  
    public Sound Sound;
    
    public AudioClip AudioClip;
}
