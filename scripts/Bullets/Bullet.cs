namespace benzo.scripts.Bullets;
using Godot;

public partial class Bullet : Area2D
{

    public float Speed = 500f;
    public float Gravity = 300f;
    [Export] public float Damage = 20f;

    public int SpawnMate = 0;
    private Vector2 _velocity;

    public override void _Ready()
    {
        BodyEntered+= OnBodyEntered;
        _velocity = new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation)) * Speed;
        Timer timer = GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += QueueFree;
    }

    protected virtual void OnBodyEntered(Node2D body)
    {
        if (body is not User user) return;
        if (user.Me != SpawnMate)
            user.DealDamage(Damage);
    }

    public override void _Process(double delta)
    {
        float angle = _velocity.Angle();
        float gravityModifier = 2 + Mathf.Sin(angle);

        _velocity += Vector2.Down * Gravity * gravityModifier * (float)delta;

        Position += _velocity * (float)delta;
        Rotation = _velocity.Angle();
    }
    


}