using Godot;

namespace benzo.scripts.globalClass;

public partial class KeyBoardInput : InputManager
{
    public override Vector2 GetMovementVector()
    {
        Vector2 dir = Vector2.Zero;

        if (Input.IsActionPressed("a")) dir.X -= 1;
        if (Input.IsActionPressed("d")) dir.X += 1;
        return dir.Normalized();
    }
}