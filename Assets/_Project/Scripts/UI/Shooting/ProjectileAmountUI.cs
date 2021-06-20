using UnityEngine;
using TMPro;

public sealed class ProjectileAmountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _projectileAmountText;

    public void UpdateProjectileAmountUI(int projectileAmount)
    {
        _projectileAmountText.text = "Balls: " + projectileAmount.ToString();

        UpdateProjectileAmountColorUI(projectileAmount);
    }

    private void UpdateProjectileAmountColorUI(int projectileAmount)
    {
        if(projectileAmount <= 0)
            _projectileAmountText.color = Color.red;
    }
}