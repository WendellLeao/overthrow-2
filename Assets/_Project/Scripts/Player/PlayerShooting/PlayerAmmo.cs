public sealed class PlayerAmmo
{
    private ProjectileAmountUI _projectileAmountUI;
    
    private int _currentProjectileAmount;
    
    public int GetCurrentProjectileAmount => _currentProjectileAmount;

    public PlayerAmmo(int projectileAmount, ProjectileAmountUI projectileAmountUI)
    {
        _projectileAmountUI = projectileAmountUI;

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
        _currentProjectileAmount++;
        
        UpdateProjectileAmountUI();
    }

    public void UpdateProjectileAmountUI()
    {
        _projectileAmountUI.OnPlayerShot_UpdateProjectileAmountUI(_currentProjectileAmount);
    }
}