using Godot;
using System;
using System.Linq;
using benzo.scripts;

public partial class Menu : Control
{
	Button lp1, lp2, lp3, lp4, start;
	Sprite2D p1, p2, p1weapon, p2weapon;
	private int p1index = 0, p2index = 0;
	
	private readonly string[] weaponPaths =
	[
		"res://brackeys_platformer_assets/drawed/ice_sword.png",
		"res://brackeys_platformer_assets/drawed/ashsword.png",
		"res://brackeys_platformer_assets/drawed/bow.png",
		"res://brackeys_platformer_assets/drawed/mage stuff.png"
	];

	private Texture2D[] weapons;
	public override void _Ready()
	{
		weapons = weaponPaths.Select(path => GD.Load<Texture2D>(path)).ToArray();
		
		lp1 = GetNode<Button>("Button");
		lp2 = GetNode<Button>("Button2");
		lp3 = GetNode<Button>("Button3");
		lp4 = GetNode<Button>("Button4");
		start = GetNode<Button>("start");
		
		p1 = GetNode<Sprite2D>("p1");
		p2 = GetNode<Sprite2D>("p2");
		p1weapon = p1.GetNode<Sprite2D>("wep");
		p2weapon = p2.GetNode<Sprite2D>("wep");

		lp1.Pressed += () => SetWeapon(ref p1index, -1, p1weapon);
		lp2.Pressed += () => SetWeapon(ref p1index, 1, p1weapon);

		lp3.Pressed+= () =>  SetWeapon(ref p2index, -1, p2weapon);
		lp4.Pressed += () => SetWeapon(ref p2index, 1, p2weapon);

		start.Pressed += InitGame;

		SetWeapon(ref p1index, 0, p1weapon);
		SetWeapon(ref p2index, 0, p2weapon);
	}

	void SetWeapon(ref int index, int dir, Sprite2D sprite)
	{
		GD.Print(index," and ",weapons.Length);
		index = (index + dir+ weapons.Length) % weapons.Length;
		sprite.Texture = weapons[index];
	}
	
	Node2D CreatePlayer(int hp, int energy, Vector2 position, int weaponIndex, int input, int him)
	{
		var builder = new Builder.UserBuilder();
		return builder
			.SetHp(hp)
			.SetMaxHp(hp)
			.SetEnergy(energy)
			.SetMaxEnergy(100)
			.SetPosition(position)
			.SetWeapon(weaponIndex)
			.SetSecondWeapon(weaponIndex)
			.SetInputManager(input)
			.SetHim(him)
			.Build();
	}

	void InitGame()
	{
		var node = GD.Load<PackedScene>("res://scenes/player/testmap.tscn").Instantiate<Testmap>();
		GetParent().AddChild(node);

		var player1 = CreatePlayer(100, 50, new Vector2(180, 350), p1index, 0, 0);
		var player2 = CreatePlayer(100, 50, new Vector2(580, 350), p2index, 1, 1);

		node.AddChild(player1);
		node.AddChild(player2);
		node.UserLoaded();
		QueueFree();
	}
}
