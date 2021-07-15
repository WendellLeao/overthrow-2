using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public sealed class DamageEffectUI : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private Image _damageEffectImage;

	[Header("Game Events")]
	[SerializeField] private LocalGameEvents _localGameEvents;

	[Header("Damage Effect")]
	private Color _startImageColor;

	private float _imageAlpha = 100f;

	private bool _canHideDamageEffect = false;
    
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
		SetStartColor(_damageEffectImage.color);
	}

	private void SubscribeEvents()
	{
		_localGameEvents.OnHealthChanged += OnHealthChanged_ShowDamageEffect;
	}

	private void UnsubscribeEvents()
	{
		_localGameEvents.OnHealthChanged -= OnHealthChanged_ShowDamageEffect;
	}

	private void Update()
	{
		HandleDamageImageEffect();
	}

	private void SetStartColor(Color startColor)
	{
		_startImageColor = startColor;
	}
	
	private void OnHealthChanged_ShowDamageEffect(int currentHealthAmount, int maxHealthAmount)
	{
		ResetImageColor();

		_damageEffectImage.enabled = true;

		StartCoroutine(TimeToHideDamageEffect());
	}

	private IEnumerator TimeToHideDamageEffect()
	{
		float timeToStartRoutine = 0.5f;
		
		yield return new WaitForSeconds(timeToStartRoutine);

		_canHideDamageEffect = true;
	}

	private void HandleDamageImageEffect()
	{
		if(_canHideDamageEffect)
		{
			if (_damageEffectImage.color.a > 0f)
			{
				float speedToHide = 30f;
						
				_imageAlpha -= Time.deltaTime * speedToHide;

				Color newColor = new Color(_startImageColor.r, _startImageColor.g, _startImageColor.b, _imageAlpha * 0.01f);

				_damageEffectImage.color = newColor;
			}
			else
			{
				ResetImageColor();

				_canHideDamageEffect = false;
			}
		}
	}

	private void ResetImageColor()
	{
		_imageAlpha = 100f;

		_damageEffectImage.enabled = false;
		
		_damageEffectImage.color = _startImageColor;
	}
}