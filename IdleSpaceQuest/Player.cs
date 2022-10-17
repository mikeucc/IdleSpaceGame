using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Vector2 screenSize;
    public int speed = 400;
    public Projectile projectile;
    public Missile missile;
    public int maxMissileCount;
    public int currentMissileCount;


    public KinematicCollision2D collision;
    public PackedScene projectileScene;
    public PackedScene missileScene;
    public Timer myTimer;
    public bool canFireProjectile;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;

        myTimer = GetNode<Timer>("Ship/Timer");
        canFireProjectile = true;

        projectileScene = (PackedScene)ResourceLoader.Load("res://Projectile.tscn");
        missileScene = (PackedScene)ResourceLoader.Load("res://homingMissile.tscn");

        maxMissileCount = 5;
        currentMissileCount = 0;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.

    public override void _PhysicsProcess(float delta)
    {
        
        Vector2 shipPosition = Vector2.Zero;


        shipPosition.x += Input.GetActionStrength("move_right", false) - Input.GetActionStrength("move_left", false);
        shipPosition.y += Input.GetActionStrength("move_down", true) - Input.GetActionStrength("move_up", true);

        shipPosition = shipPosition.Normalized() * speed * delta;

        collision= MoveAndCollide(shipPosition);

       if(collision != null)
        {
            GD.Print(collision);
        }
        

        /* Position += shipPosition * delta;
         Position = new Vector2(
             x: Mathf.Clamp(Position.x, 5, screenSize.x - 300),
                 y: Mathf.Clamp(Position.y, 5, screenSize.y)
             );
        */

        if (Input.IsActionPressed("ui_accept"))
        {
            if (canFireProjectile)
            {
                projectile = (Projectile)projectileScene.Instance();
                GetParent().AddChild(projectile);
                projectile.Position = GetNode<Position2D>("Ship/Accuracy/Position2D").GlobalPosition;
                projectile.angle = (float)GD.RandRange(-0.78, 0.78);

                projectile.velocityAdjustment();
                canFireProjectile = false;
                myTimer.Start();
            }

        }
    }


   

    public void projectileWeaponCooldown()
    {
        canFireProjectile = true;
    }

    public void OnMissileRadarBodyEntered(Enemy enemy)
    {
        if (currentMissileCount<maxMissileCount)
        {
            enemy.Targeted();

            missile = (Missile)missileScene.Instance();
            missile.target = enemy;
            missile.Position= GetNode<Position2D>("Ship/Accuracy/Position2D").GlobalPosition;
            GetParent().CallDeferred("add_child", missile);
            currentMissileCount++;
        }

        //missile.Position= GetNode<Position2D>("Ship/Accuracy/Position2D").GlobalPosition;

    }
}
