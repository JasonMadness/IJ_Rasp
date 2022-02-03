using System;

class Weapon
{
    private int _damage;
    private int _minDamage = 1;
    private int _maxDamage = 5;
    private int _bullets;
    private int _maxBullets = 30;

    private const int BulletsPerShot = 1;

    public Weapon(int damage, int bullets)
    {
        if (damage < _minDamage || damage > _maxDamage)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (bullets < 0 || bullets > _maxBullets)
            throw new ArgumentOutOfRangeException(nameof(bullets));

        _damage = damage;
        _bullets = bullets;
    }

    public void TryFire(Player player)
    {
        if (CanFire())
        {
            Fire(player);
        }
    }

    private bool CanFire()
    {
        return _bullets > BulletsPerShot;
    }

    private void Fire(Player player)
    {
        player.TakeDamage(_damage);
        _bullets -= BulletsPerShot;
    }
}

class Player
{
    private int _health;
    private int _maxHealth = 30;

    public bool IsAlive { get; private set; }

    public Player(int health)
    {
        if (health < 0 || health > _maxHealth)
            throw new ArgumentOutOfRangeException(nameof(health));

        _health = health;
        IsAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

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
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException(nameof(weapon));
        else
            _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player.IsAlive == true)
            _weapon.TryFire(player);
    }
}