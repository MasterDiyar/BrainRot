using Godot;
using System;
using benzo.scripts.Bullets;

public partial class Arrow : Bullet
{
    protected override void OnBodyEntered(Node2D body)
    {
        base.OnBodyEntered(body);
        if (body is User user) 
            if (user.Me != SpawnMate)
                QueueFree();
        
    }
}
