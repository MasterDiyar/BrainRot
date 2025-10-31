using Godot;
using System;
using benzo.scripts;
using benzo.scripts.globalClass;

public partial class User : CharacterBody2D
{
    [Export]public InputManager inputManager { get; set; }
    public event Action<float> HealthChanged ;
    public event Action<float> EnergyChanged ;

    public float MaxHp { get; set; } = 100;
    public float Hp { get; set; } = 100;
    public float MaxEnergy { get; set; } = 100;
    public float Energy { get; set; } = 100;
    
    public Weapon Weapon { get; set; }
    public Weapon SecondWeapon { get; set; }
    public Weapon CurrentWeapon;

    public int Me = 0;

    public AnimatedSprite2D sprite;

    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        sprite.Play("idle");
        CurrentWeapon = Weapon;
    }

    public override void _Process(double delta)
    {
        if (Energy < MaxEnergy) Energy += (float)delta*10;

        if (Me ==0) {
            if (Input.IsActionJustPressed("lm") && Energy > CurrentWeapon.consumeEnergy)
            {
                CurrentWeapon.ExecuteAttack(GetAngleTo(GetGlobalMousePosition()));
                Energy -= CurrentWeapon.consumeEnergy;
                
            }
        } else {
            if (Input.IsActionJustPressed("r2") && Energy > CurrentWeapon.consumeEnergy)
                HandleGamepadAttack();
        }
        EnergyChanged?.Invoke(Energy / MaxEnergy);
    }
    
    private void HandleGamepadAttack()
    {
        float joyX = Input.GetActionStrength("rsr") - Input.GetActionStrength("rsl");
        float joyY = Input.GetActionStrength("rsd") - Input.GetActionStrength("rsu");

        Vector2 dir = new Vector2(joyX, joyY);
        
        float angle = dir.Angle();
        CurrentWeapon.ExecuteAttack(angle);
        Energy -= CurrentWeapon.consumeEnergy;
    }

    public void DealDamage(float damage)
    {
        GD.Print("Dealed Damage: " + damage);
        
        Hp -= damage;
        HealthChanged?.Invoke(Hp/MaxHp);
    }
}
