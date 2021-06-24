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
        _currentProjectileAmount++;
        
        UpdateProjectileAmountUI();
    }

    public void UpdateProjectileAmountUI()
    {
        CanvasAssets.instance.GetProjectileAmountUI.UpdateProjectileAmountUI(_currentProjectileAmount);
    }
}
