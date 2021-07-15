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
	
	private void SubscribeEvents()
	{
		_audioVolumeSlider.onValueChanged.AddListener(SetVolumeSliderValue);
	}
	
	private void UnsubscribeEvents()
	{
		_audioVolumeSlider.onValueChanged.RemoveAllListeners();
	}

	private void SetVolumeSliderValue(float sliderValue)
	{
		_audioMixer.SetFloat("volume", Mathf.Log10((sliderValue) * 10f));
	}
}