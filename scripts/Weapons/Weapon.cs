using Godot;

namespace benzo.scripts;

public partial class Weapon : Sprite2D
{
    [Export] public PackedScene BulletScene;
    [Export] public float Damage = 20f;

    protected Tween animation;

    public float consumeEnergy = 10;
    public bool isAttacking = false;

    public virtual void ExecuteAttack(float angle)
    {
        
    }

    public virtual void Animation()
    {
        
    }

}