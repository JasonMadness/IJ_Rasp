class Player { }
class Gun { }
class TargetFollower { }
class UnitsGetter
{
    public IReadOnlyCollection<Unit> Units { get; private set; }
}