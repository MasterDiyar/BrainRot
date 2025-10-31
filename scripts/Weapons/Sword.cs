namespace benzo.scripts;

using Godot;
public partial class Sword : Weapon
{
    [Export] public PackedScene SwingScene;
    public float AttackRange = 64;
    protected float Amplification = 1, movePosAmplifier = 1;
    public override void ExecuteAttack(float angle)
    {
        if (isAttacking) return;
        isAttacking = true;
        var swing = SwingScene.Instantiate<Swing>();
        
        swing.GlobalPosition = GlobalPosition;
        swing.GlobalRotation = GlobalRotation;
        swing.Scale = new Vector2((FlipH) ? -1 : 1, 1) * Amplification;
        
        GetTree().Root.AddChild(swing);
        
        Animation();
    }

    public override  void Animation()
    {
        animation ??= CreateTween();
        animation.Kill(); 
        animation = CreateTween();

        float startRotation = RotationDegrees;
        float swingDown = (FlipH) ? startRotation - 90f: startRotation + 90f;
        Vector2 movePos = (FlipH) ? new Vector2(-20, 0f) : new Vector2(20f,0);
        movePos *= movePosAmplifier;        
        
        animation.Parallel()
            .TweenProperty(this, "rotation_degrees", swingDown, 0.4f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.Out);

        animation.Parallel()
            .TweenProperty(this, "position", movePos, 0.4f)
            .SetTrans(Tween.TransitionType.Sine);

        animation.TweenProperty(this, "rotation_degrees", startRotation, 0.2f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.In);

        animation.Parallel()
            .TweenProperty(this, "position", Vector2.Zero, 0.1f)
            .SetTrans(Tween.TransitionType.Sine);
        
        animation.Finished += () =>
        isAttacking = false;
    }


}