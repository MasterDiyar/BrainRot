using Godot;
using System;

public partial class Testmap : Node2D
{
	[Export] Line2D hpLine1, hpLine2, energyLine1, energyLine2;
	private float length = 169;

	public void UserLoaded()
	{
		foreach (var node in GetChildren())
		{
			if (node is User user)
			{
				GD.Print("Has player", user.Me);
				var (hpLine, energyLine) = user.Me == 0 
					? (hpLine1, energyLine1) 
					: (hpLine2, energyLine2);
            
				user.HealthChanged += ratio => UpdateLine(hpLine, ratio);
				user.EnergyChanged += ratio => UpdateLine(energyLine, ratio);
			}
		}
	}

	private void UpdateLine(Line2D line, float ratio)
	{
		line.SetPointPosition(1, Vector2.Right * ratio * length);
	}
}
