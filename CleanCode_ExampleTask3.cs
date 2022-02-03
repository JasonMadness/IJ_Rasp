class Weapon
{
    private int _bullets;
    private const int BulletsPerShot = 1;

    public bool CanShoot() => _bullets >= BulletsPerShot;

    public void Shoot() => _bullets -= BulletsPerShot;
}