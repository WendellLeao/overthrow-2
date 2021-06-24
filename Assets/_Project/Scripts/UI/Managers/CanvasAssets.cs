using UnityEngine;

public sealed class CanvasAssets : MonoBehaviour
{
    public static CanvasAssets instance;

    [Header("Panels")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;
    [SerializeField] private GameObject pausePanelObject;

    [Header("Health System UI")]
    [SerializeField] private HealthBarUI _healthBarUI;

    [Header("Shooting UI")]
    [SerializeField] private ProjectileAmountUI _projectileAmountUI;

    public ProjectileAmountUI GetProjectileAmountUI => _projectileAmountUI;

    public HealthBarUI GetHealthBarUI => _healthBarUI;

    public GameObject GetGameOverPanelObject => _gameOverPanelObject;
    public GameObject GetWinPanelObject => _winPanelObject;
    public GameObject GetPausePanelObject => pausePanelObject;

    private void Awake()
    {
        instance = this;
    }
}