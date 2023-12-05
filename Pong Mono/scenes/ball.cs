using Godot;
using System;

public partial class ball : CharacterBody2D
{
    public float InitialBallSpeed = 150;
    public float SpeedMultiplier = 1.1f;
    private bool started;
    public float _speed;

    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
        var velocity = Velocity;
        var collision = MoveAndCollide(velocity * (float)delta);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.GetNormal());
            velocity = velocity * velocity.Normalized().Length() * SpeedMultiplier;
            Velocity = velocity;
            _speed = Math.Abs(Velocity.X * Velocity.Y) / 1000;
            GD.Print((int)_speed);
        }
    }
    
    public void StartBall()
    {
        GD.Print("StartBall");
        var direction = new Vector2(0, 0);
        Position = Vector2.Zero;
        var random = new Random();
        switch (random.Next(1, 4))
        { 
            case 1:
                direction.X += random.Next(1, 5);
                direction.Y += random.Next(1, 5);
                break;
            case 2:
                direction.X += -random.Next(1, 5);
                direction.Y += random.Next(1, 5);
                break;
            case 3:
                direction.X += random.Next(1, 5);
                direction.Y += -random.Next(1, 5);
                break;
            case 4:
                direction.X += -random.Next(1, 5);
                direction.Y += -random.Next(1, 5);
                break;
        }
        Velocity = new Vector2(direction.X, direction.Y) * InitialBallSpeed;
    }
}
    