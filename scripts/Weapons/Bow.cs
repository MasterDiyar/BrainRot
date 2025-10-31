using Godot;
using System;
using benzo.scripts;

public partial class Bow : Weapon
{
	public override void _Ready()
	{
		BulletScene = GD.Load<PackedScene>("res://scenes/player/bullets/arrow.tscn");
	}

	public override void ExecuteAttack(float angle)
	{
		var arrow = BulletScene.Instantiate<Arrow>();	
		arrow.GlobalPosition = GlobalPosition;
		arrow.GlobalRotation = angle;
		arrow.SpawnMate = GetParent<User>().Me;
		
		GetTree().Root.AddChild(arrow);
	}
}
