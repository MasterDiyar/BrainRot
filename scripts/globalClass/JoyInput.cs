namespace benzo.scripts.globalClass;

using Godot;
using System;

public partial class JoyInput : InputManager
{


    public override Vector2 GetMovementVector()
    {
        Vector2 dir = Vector2.Zero;
        if (Input.IsActionPressed("ja")) dir.X -= 1;
        if (Input.IsActionPressed("jd")) dir.X += 1;
        //if (Input.IsActionPressed("jw")) dir.Y -= 1;
        //if (Input.IsActionPressed("js")) dir.Y += 1;

        return dir.Normalized();
    }
}