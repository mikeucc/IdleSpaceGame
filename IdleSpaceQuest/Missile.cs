using Godot;
using System;
using System.Collections.Generic;

public class Missile : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


    [Export]
    public float speed = 500;
    [Export]
    public float steerForce = 40.0f;


    public Vector2 velocity = Vector2.Zero;
    public Vector2 acceleration = Vector2.Zero;
    public Enemy target;
    public Player player;

    public List<Enemy> insideDestructionList;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RotationDegrees += (float)GD.RandRange(-35, 35);
        velocity = Transform.x * speed;
        insideDestructionList = new List<Enemy>();
        player = GetNode<Player>("../Player");
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    public override void _PhysicsProcess(float delta)
    {
        if(target is null)
        {
            return;
        }
        else
        {
            if (IsInstanceValid(target))
            {

                acceleration = Seek();
                velocity += acceleration * delta;
                velocity = velocity.LimitLength(speed);
                Rotation = velocity.Angle();
                Position += velocity * delta;
            }
            
        }
    }

    public Vector2 Seek()
    {
        Vector2 steer= Vector2.Zero;

        if(target!=null)
        {
            Vector2 desired;
            desired=(target.GlobalPosition-GlobalPosition).Normalized()*speed;
           
            steer = (desired - velocity).Normalized() * steerForce;

            
        }


        return steer;
    }


    public void Die()
    {
        //instance explosion
        //var instance = explosion.instance()

        //instance.global_transform = global_transform

        //get_parent().call_deferred("add_child", instance)

        if (insideDestructionList.Contains(target))
        {
            try
            {
                target.Die();
            }
            catch(Exception e)
            {
                GD.Print(e);
            }
        }

        player.currentMissileCount--;
        this.QueueFree();


    }


    public void OnHomingMissileBodyEntered(Enemy en)
    {
        Die();
        GD.Print("OnHomingMissileBodyEntere");
    }

    public void OnTimerTimeout()
    {
        target.targetLock = false;
        Die();

    }

    public void OnDestructionBodyEntered(Enemy en)
    {
        GD.Print("OnDestructionBodyEntered");
        insideDestructionList.Add(en);

        GD.Print(insideDestructionList);
    }

    public void OnDestructionBodyExited(Enemy en)
    {
        GD.Print("OnDestructionBodyExited");
        insideDestructionList.Remove(en);
    }
}
