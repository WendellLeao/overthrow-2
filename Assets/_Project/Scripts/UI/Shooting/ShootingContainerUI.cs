using UnityEngine;

public sealed class ShootingContainerUI : MonoBehaviour
{
    public static ShootingContainerUI instance;

    [Header("Canvas Assets")]
    [SerializeField] private ProjectileAmountUI _projectileAmountUI;
    public ProjectileAmountUI ProjectileAmountUI => _projectileAmountUI;

    private void Awake()
    {
        instance = this;
    }
}
