using Godot;
using System;
using benzo.scripts.Bullets;

public partial class Star : Bullet{
    public override void _Ready()
    {
        Speed = 700;
        Gravity = 10;
        
        base._Ready();
        
    }
}
