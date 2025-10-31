using Godot;
using System;
using benzo.scripts;

public partial class Potion : Weapon
{
    public override void ExecuteAttack(float angle)
    {
        GetParent<User>().DealDamage(-Damage);
    }
}
