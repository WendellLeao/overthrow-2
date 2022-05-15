namespace _Project.Scripts.Player.PlayerShooting
{
    public sealed class PlayerAmmo
    {
        private int _currentProjectileAmount;
    
        public PlayerAmmo(int maxProjectileAmount)
        {
            _currentProjectileAmount = maxProjectileAmount;
        }

        public void DecreaseAmmo()
        {   
            _currentProjectileAmount--;
        }
    
        public int GetCurrentProjectileAmount()
        {
            return _currentProjectileAmount;
        }
    }
}
