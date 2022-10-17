using Godot;
using System;

public class Projectile : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public Vector2 velocity = Vector2.Zero;
    public int speed = 1000;
    public float angle;
    public Sprite mySprite;

    public KinematicCollision2D collision;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        velocity = new Vector2(1, 0);
        angle = 0.785f;

        mySprite = GetNode<Sprite>("Sprite");
    }

    public override void _PhysicsProcess(float delta)
    {
       collision=MoveAndCollide(velocity.Normalized()*delta*speed);

        if(collision!=null)
        {
            this.QueueFree();
            GD.Print("It's a Hit!!");
        }
       
    }

    public void velocityAdjustment()
    {
        this.velocity=velocity.Rotated(angle);
        mySprite.Rotate(angle);
    }

    public void ExitedScreen()
    {
        this.QueueFree();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
