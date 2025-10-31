using benzo.scripts.globalClass;
using Godot;

namespace benzo.scripts.player;

public partial class Movement : Node
{
    [Export]private User parent;
    
    [Export] public float Speed { get; set; } = 100f;
    [Export] public float JumpForce { get; set; } = 400f;
    [Export] public float Gravity { get; set; } = 800f;

    private Vector2 _velocity = Vector2.Zero;
    private bool facingDirection = false;
    public override void _Ready()
    {
        parent ??= GetParent() as User;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (parent.inputManager == null)
            GD.Print("parent input manager is null");
        
        Vector2 direction = Vector2.Zero;

        direction = parent.inputManager.GetMovementVector();
        facingDirection = direction.X == -1;
        
        if (!parent.IsOnFloor())
            _velocity.Y += Gravity * (float)delta;
        else if (Input.IsActionJustPressed("space") && parent.Me == 0)
            _velocity.Y = -JumpForce;
        else if (Input.IsActionJustPressed("x") && parent.Me == 1)
            _velocity.Y = -JumpForce;

        _velocity.X = direction.X * Speed;
        
        if (direction.X != 0)
        {
            parent.GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = facingDirection;
            foreach (var node in parent.GetChildren())
            {
                if (node is Weapon wep)
                    wep.FlipH = facingDirection;
            }
        }

        parent.Velocity = _velocity;
        parent.MoveAndSlide();
    }
}