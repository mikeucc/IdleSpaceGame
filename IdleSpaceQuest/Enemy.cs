using Godot;
using System;

public class Enemy : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Sprite targetActive;
    public bool targetLock;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        targetActive = GetNode<Sprite>("Targeted");

        GD.Print(targetActive);
        targetLock = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void Targeted()
    {
        GD.Print(targetActive);
        if(!targetLock)
        {
            targetActive.Visible = true;
            targetLock = true;
            GD.Print(targetActive.Visible);
        }
    }

    public void Die()
    {
        QueueFree();

    }
}
