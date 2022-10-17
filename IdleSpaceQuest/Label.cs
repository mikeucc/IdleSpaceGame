using Godot;
using System;

public class Label : Godot.Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public int drawSpeed;
    public int chatterLimit;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        drawSpeed = 0;
        chatterLimit = 56;
    }

    public void showChatter()
    {
        if (drawSpeed<chatterLimit)
        {
            drawSpeed += 1;
            this.VisibleCharacters = drawSpeed;
        }
        
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      showChatter();
  }
}
