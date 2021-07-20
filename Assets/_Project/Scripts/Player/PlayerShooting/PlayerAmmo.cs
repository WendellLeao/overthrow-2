public sealed class PlayerAmmo
{
    private int _currentProjectileAmount;
    
    public int GetCurrentProjectileAmount => _currentProjectileAmount;

    public PlayerAmmo(int maxProjectileAmount)
    {
        _currentProjectileAmount = maxProjectileAmount;
    }

    public void DecreaseAmmo()
    {   
        _currentProjectileAmount--;
    }
}
