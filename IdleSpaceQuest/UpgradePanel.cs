using Godot;
using System;

public class UpgradePanel : Panel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public ScrollContainer scrollContainer;
    public ScrollBar scrollBar;

    public int maxScrollLength;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scrollContainer = GetNode<ScrollContainer>("Panel/ScrollContainer");
        scrollBar = scrollContainer.GetVScrollbar();

        scrollBar.Connect("changed", this, "ScrollBarChanged");
        maxScrollLength = (int)scrollBar.MaxValue;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    public void ScrollBarChanged()
    {
        if (maxScrollLength < scrollBar.MaxValue)
        {
            scrollContainer.ScrollVertical = (int)scrollBar.MaxValue;
            maxScrollLength = (int)scrollBar.MaxValue;
        }

        
    }

    public void ChangeToBattleScene()
    {
        GetTree().ChangeScene("res://BattleScene.tscn");
    }
}