class Weapon
{
    private int _damage;
    private int _bullets;

    public Weapon(int damage, int bullets)
    {
        if (damage < 0)
            _damage = 0;
        else
            _damage = damage;

        if (bullets < 0)
            _bullets = 0;
        else
            _bullets = bullets;
    }

    public void Fire(Player player)
    {
        if (_bullets > 0)
        {
            player.TakeDamage(_damage);
            _bullets -= 1;
        }
    }
}

class Player
{
    private int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}

class Bot
{
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}