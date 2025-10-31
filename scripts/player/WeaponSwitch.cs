using Godot;

namespace benzo.scripts.player;

public partial class WeaponSwitch : Node
{
    [Export] private User Parent;

    private readonly string[][] _controls = new string[][]
    {
        new[] { "rollup", "rolld" }, 
        new[] { "l1", "r1" }            
    };

    public override void _Ready()
    {
        Parent ??= GetParent<User>();
    }

    public override void _Process(double delta)
    {
        if (Parent == null)
            return;

        if (Parent.Me == 0) {
            if (Input.IsActionJustPressed(_controls[0][0])|| Input.IsActionJustPressed(_controls[0][1]))
                SwitchWeapon();
        } else {
            if (Input.IsActionJustPressed(_controls[1][0]) || Input.IsActionJustPressed(_controls[1][1]))
                SwitchWeapon();
        }
        
    }

    private void SwitchWeapon()
    {
        if (Parent.Weapon == null || Parent.SecondWeapon == null)
            return;
        Parent.CurrentWeapon.Position = Vector2.One * 390625;
        Parent.CurrentWeapon = Parent.CurrentWeapon == Parent.Weapon ? Parent.SecondWeapon : Parent.Weapon;
        Parent.CurrentWeapon.Position = Vector2.Zero;
    }
}