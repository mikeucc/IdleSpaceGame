using Godot;
using System;

public class ScrollContainer : Godot.ScrollContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public Label textOutput;
    public PackedScene labelScene;
    public VBoxContainer vb;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        vb = GetNode<VBoxContainer>("ActionLog");
        labelScene = (PackedScene)ResourceLoader.Load("res://ActionLabel.tscn");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void ScrollBarChanged()
    {

    }



    public void addEntry(String s)
    {

        textOutput = (Label)labelScene.Instance();
        vb.AddChild(textOutput);
        textOutput.drawSpeed = 0;
        textOutput.Text = s;

        if (vb.GetChildCount() > 10)
        {
            vb.GetChild(0).QueueFree();
        }
    }
}
