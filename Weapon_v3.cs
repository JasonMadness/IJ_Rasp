public class Weapon
{
    private const int BulletsPerShot = 1;

    private int _damage;
    private int _bullets;

    public Weapon(int damage, int bullets)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (bullets < 0)
            throw new ArgumentOutOfRangeException(nameof(bullets));

        _damage = damage;
        _bullets = bullets;
    }

    public void Fire(Player player)
    {
        if (CanFire() == true)
        {
            player.TakeDamage(_damage);
            _bullets -= BulletsPerShot;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private bool CanFire()
    {
        return _bullets >= BulletsPerShot;
    }
}

public class Player
{
    private int _health;

    public Player(int health)
    {
        if (health < 0)
            throw new ArgumentOutOfRangeException(nameof(health));

        _health = health;
    }

    public bool IsAlive()
    {
        return _health > 0;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _health -= damage;
    }
}

public class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException(nameof(weapon));

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player.IsAlive() == true)
            _weapon.Fire(player);
    }
}