using UnityEngine;
using TMPro;

public sealed class ProjectileAmountUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text _projectileAmountText;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    // private void SubscribeEvents()
    // {
    //     _localGameEvent.OnReadPlayerInputs += OnPlayerShot_PerformShoot;
    // }

    // private void UnsubscribeEvents()
    // {
    //     _localGameEvent.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
    // }

    public void OnPlayerShot_UpdateProjectileAmountUI(int projectileAmount)
    {
        _projectileAmountText.text = "Ammo: " + projectileAmount.ToString();

        UpdateProjectileAmountColorUI(projectileAmount);
    }

    private void UpdateProjectileAmountColorUI(int projectileAmount)
    {
        if(projectileAmount <= 0)
        {
            _projectileAmountText.color = Color.red;
        }
    }
}