using Godot;
using System;

public class Upgrade_Panel : Panel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public ScrollContainer scrollContainer;
    public ScrollBar scrollBar;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scrollContainer = GetNode<ScrollContainer>("/root/Upgrade Panel/Panel/ScrollContainer");
        scrollBar = scrollContainer.GetVScrollbar();

        scrollBar.Connect("changed", this, "ScrollBarChanged");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
