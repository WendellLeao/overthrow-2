public sealed class PlayerAmmo
{
    private int _currentProjectileAmount;
    public int GetCurrentProjectileAmount => _currentProjectileAmount;

    public PlayerAmmo(int projectileAmount)
    {
        _currentProjectileAmount = projectileAmount;

        UpdateProjectileAmountUI();
    }

    public void DecreaseAmmo()
    {   
        _currentProjectileAmount--;
        
        UpdateProjectileAmountUI();
    }

    public void IncreaseAmmo()
    {
        //code here
    }

    public void UpdateProjectileAmountUI()
    {
        ShootingContainerUI.instance.ProjectileAmountUI.UpdateProjectileAmountUI(_currentProjectileAmount);
    }
}
