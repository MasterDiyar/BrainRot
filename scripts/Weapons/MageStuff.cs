using Godot;
using System;
using benzo.scripts;

public partial class MageStuff : Weapon
{
	
	public override void _Ready()
	{
		BulletScene = GD.Load<PackedScene>("res://scenes/player/bullets/star.tscn");
	}

	public override void ExecuteAttack(float angle)
	{
		var star = BulletScene.Instantiate<Star>();	
		star.GlobalPosition = GlobalPosition;
		star.GlobalRotation = angle;
		star.SpawnMate = GetParent<User>().Me;
		
		GetTree().Root.AddChild(star);
	}
}
