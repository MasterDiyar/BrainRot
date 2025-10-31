using Godot;

namespace benzo.scripts;

public class WeaponFactory
{
    public static Ashsword CreateAshsword()
    {
        return GD.Load<PackedScene>("res://scenes/player/weapons/ashsword.tscn").Instantiate<Ashsword>();
    }

    public static IceSword CreateIceSword()
    {
        return GD.Load<PackedScene>("res://scenes/player/weapons/ice_sword.tscn").Instantiate<IceSword>();
    }

    public static MageStuff CreateMageStuff()
    {
        return GD.Load<PackedScene>("res://scenes/player/weapons/mage_stuff.tscn").Instantiate<MageStuff>();
    }

    public static Bow CreateBow()
    {
        return GD.Load<PackedScene>("res://scenes/player/weapons/bow.tscn").Instantiate<Bow>();
    }

    public static Potion CreatePotion()
    {
        return GD.Load<PackedScene>("res://scenes/player/weapons/potion.tscn").Instantiate<Potion>();
    }
}