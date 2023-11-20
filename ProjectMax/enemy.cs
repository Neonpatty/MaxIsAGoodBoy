using Godot;
using System;

public partial class enemy : CharacterBody3D
{
	[Export] public float enemySpeed { get; set;} = 5.1f;
	private player player;

	public override void _Ready()
	{
		player =  GetNode<player>("Player");
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}

	private void FollowPlayer(double delta)
	{
		
	}
}
