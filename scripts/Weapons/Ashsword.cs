using Godot;
using System;
using benzo.scripts;

public partial class Ashsword : Sword{
    public override void _Ready()
    {
        base._Ready();
        Amplification = 1.4f;
        movePosAmplifier = 2.6f;
    }
}
