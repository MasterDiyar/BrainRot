using Godot;
using System;
using benzo.scripts.Bullets;

public partial class Swing : Bullet
{
	[Export] private AnimatedSprite2D anim;

	public override void _Ready()
	{
		base._Ready();
		anim.Play();
		var time = GetNode<Timer>("Timer");
		time.SetWaitTime(5/8f);
		anim.AnimationFinished += QueueFree;
	}

	public override void _Process(double delta)
	{
		
	}
}
