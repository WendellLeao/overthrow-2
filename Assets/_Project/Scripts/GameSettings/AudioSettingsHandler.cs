using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Project.Scripts.GameSettings
{
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
		
			SetAudioMixerValue(SaveSystem.SaveSystem.GetLocalData().AudioMixerValue);
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
			_audioVolumeSlider.value = SaveSystem.SaveSystem.GetLocalData().AudioMixerValue;
		}
	
		private void SaveAudioMixerValue(float audioMixerValue)
		{
			SaveSystem.SaveSystem.GetLocalData().AudioMixerValue = audioMixerValue;
		
			SaveSystem.SaveSystem.SaveGameData();
		}

		private void SetAudioMixerValue(float sliderValue)
		{
			float newAudioMixerValue = Mathf.Log10(sliderValue) * 20f;
		
			_audioMixer.SetFloat("volume", newAudioMixerValue);

			SaveAudioMixerValue(sliderValue);
		}
	}
}
