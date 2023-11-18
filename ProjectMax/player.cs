using Godot;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

public partial class player : CharacterBody3D
{
    [Export] public int speed { get; set; } = 15;

    private Godot.Vector3 targetVelocity = Godot.Vector3.Zero;

    public override void _PhysicsProcess(double delta)
    {
        Movement();
    }

    private void Movement()
    {
        var direction = Godot.Vector3.Zero;

        if(Input.IsActionPressed("move_right"))
        {
            direction.X += 1.0f;
        }
        if(Input.IsActionPressed("move_left"))
        {
            direction.X -= 1.0f;
        }
        if(Input.IsActionPressed("move_down"))
        {
            direction.Z += 1.0f;
        }
        if(Input.IsActionPressed("move_up"))
        {
            direction.Z -= 1.0f;
        }

        if(direction != Godot.Vector3.Zero)
        {
            direction = direction.Normalized();
            GetNode<Node3D>("Pivot").LookAt(Position + direction, Godot.Vector3.Up);
        }

        targetVelocity.X = direction.X * speed;
        targetVelocity.Z = direction.Z * speed;

        Velocity = targetVelocity;
        MoveAndSlide();
    }
}