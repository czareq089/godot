using Godot;
using System;

public partial class paddle : CharacterBody2D
{
    [Export]
    private float _speed = 500f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var position = Position;
        if (Input.IsActionPressed("move_up"))
        {
            position.Y -= _speed * (float)delta;
        }
        else if (Input.IsActionPressed("move_down"))
        {
            position.Y += _speed * (float)delta;
        }
        position.Y = Mathf.Clamp(position.Y, -456, 456);
        Position = position;
    }
}