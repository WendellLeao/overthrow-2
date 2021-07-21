using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public sealed class AudioSettingsHandler : MonoBehaviour
{
	[Header("Audio Mixer")]
	[SerializeField] private AudioMixer _audioMixer;
	
	[Header("Slider")]
	[SerializeField] private Slider _audioVolumeSlider;
	
	private void OnEnable()
	{
		SubscribeEvents();
	}
	
	private void OnDisable()
	{ 
		UnsubscribeEvents();
	}
	
	private void Start()
	{
		LoadAudioVolumeSlider();
		
		SetAudioMixerValue(SaveSystem.GetLocalData().AudioMixerValue);
	}
	
	private void SubscribeEvents()
	{
		_audioVolumeSlider.onValueChanged.AddListener(SetAudioMixerValue);
	}
	
	private void UnsubscribeEvents()
	{
		_audioVolumeSlider.onValueChanged.RemoveAllListeners();
	}

	private void LoadAudioVolumeSlider()
	{
		_audioVolumeSlider.value = SaveSystem.GetLocalData().AudioMixerValue;
	}
	
	private void SaveAudioMixerValue(float audioMixerValue)
	{
		SaveSystem.GetLocalData().AudioMixerValue = audioMixerValue;
		
		SaveSystem.SaveGameData();
	}

	private void SetAudioMixerValue(float sliderValue)
	{
		float newAudioMixerValue = Mathf.Log10(sliderValue) * 20f;//Magic Number!!!
		
		_audioMixer.SetFloat("volume", newAudioMixerValue);

		SaveAudioMixerValue(sliderValue);
	}
}
