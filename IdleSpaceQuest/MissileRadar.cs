using Godot;
using System;

public class MissileRadar : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    public int testInt;

    public float angleFrom;
    public float angleTo;
    public float radius;
    public Color radarColor;
     

    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        angleFrom = 0;
        angleTo = 180;
        radius = 500;
        radarColor = new Color(1,1,1,1);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    public override void _Draw()
    {
        // Your draw commands here
        var center = new Vector2(0, 0);

        DrawCircleArc(center, radius, angleFrom, angleTo, radarColor);

       
    }


   

    public void DrawCircleArc(Vector2 center, float radius, float angleFrom, float angleTo, Color color)
    {
        int nbPoints = 32;
        var pointsArc = new Vector2[nbPoints];

        for (int i = 0; i < nbPoints; ++i)
        {
            float anglePoint = Mathf.Deg2Rad(angleFrom + i * (angleTo - angleFrom) / nbPoints - 90f);
            pointsArc[i] = center + new Vector2(Mathf.Cos(anglePoint), Mathf.Sin(anglePoint)) * radius;
        }

        for (int i = 0; i < nbPoints - 1; ++i)
            DrawLine(pointsArc[i], pointsArc[i + 1], color);
    }


    public void SetArc(float radius, float angleFrom, float angleTo, Color color)
    {
        this.radius = radius;
        this.angleFrom = angleFrom;
        this.angleTo=angleTo;
        this.radarColor = color;
    }
}
