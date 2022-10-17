using Godot;
using System;

public class Resource : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    [Export]
    public string researchType;
    [Export]
    public int researchStored=0;
    [Export]
    public int researchGenerationSpeed;
    [Export]
    public bool researchEnabled;
    [Export]
    public string nextResearchType;
    [Export]
    public int nextResearchTypeCost;


    public Timer myTimer;
    public ColorRect cooldownRect;

    public Resource nextResearch;


    public override void _Ready()
    {
        myTimer = GetNode<Timer>("Timer");
        cooldownRect = GetNode<ColorRect>("ColorRect");

        this.Text = researchType + " Research Stored: " + researchStored;

        if (researchEnabled)
        {
            myTimer.Start(researchGenerationSpeed);
        }

        nextResearch = GetNode<Resource>(nextResearchType);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  
    public override void _Process(float delta)
    {
        cooldownRect.RectSize = new Vector2((myTimer.TimeLeft / myTimer.WaitTime) * 237,40);
        this.Text = researchType + " Research Stored: " + researchStored;

    }

    public void OnTimerTimeout()
    {
        researchStored++;

        if (researchStored > nextResearchTypeCost && !nextResearch.researchEnabled)
        {
            //enable next level of research

            nextResearch.researchEnabled = true;
            nextResearch.myTimer.Start(nextResearch.researchGenerationSpeed);
            researchStored = 0;
            nextResearch.Visible = true;
        }


        
    }



}
