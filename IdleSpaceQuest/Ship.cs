using Godot;
using System;

public class Ship : Sprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public MissileRadar radarArea;
    public Position2D position;
    public CollisionShape2D collisionShape;
    [Export]
    public Color radarColour;
    [Export]
    public int maxRadarRange;


    public CircleShape2D circleShape;

    public float radarGrowth=4;


    //public Starfield starfield;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        radarArea = GetNode<MissileRadar>("Accuracy/Position2D/MissileRadar");
        position = GetNode<Position2D>("Accuracy/Position2D");
        collisionShape =GetNode<CollisionShape2D>("Accuracy/Position2D/MissileRadar/Pulse");
       

        circleShape = (CircleShape2D)collisionShape.Shape;

       
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {

        circleShape.Radius += radarGrowth;
        radarGrowth+=0.75f;
       
        radarArea.SetArc(circleShape.Radius,0,420,radarColour);
        radarArea.Update();

        if (circleShape.Radius>maxRadarRange)
        {

            circleShape.Radius = 80;
            radarGrowth = 4;
          
        }

        

    }


}
