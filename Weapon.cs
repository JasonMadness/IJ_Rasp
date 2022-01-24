class Weapon
{
    private int _damage;
    private int _bullets;

    public Weapon(int damage, int bullets)
    {
        _damage = damage > 0 ? damage : 1;
        _bullets = bullets > 0 ? bullets : 1;
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

    public bool IsAlive { get; private set; }

    public Player(int health)
    {
        _health = health > 0 ? health : 1;
        IsAlive = true;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        TryDie();
    }

    private void TryDie()
    {
        IsAlive = _health > 0;
    }
}

class Bot
{
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon ?? new Weapon(1, 1);
    }

    public void OnSeePlayer(Player player)
    {
        if (player.IsAlive == true)
            _weapon.Fire(player);
    }
}