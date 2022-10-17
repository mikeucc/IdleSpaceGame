using Godot;
using System;

public class ProjectileButton : Button
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public Label textOutput;
    public Label levelLabel;
    
    public Sprite visibleShip;
    
    public Timer myTimer;
    public int level;
    public float baseWait;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        textOutput = GetNode<Label>("/root/Upgrade Panel/Panel/Label");
        levelLabel = GetNode<Label>("Level");

        visibleShip=GetNode<Sprite>("/root/Upgrade Panel/Ship/Sprite");

        myTimer = GetNode<Timer>("Timer");
        level = 0;
        baseWait = 5;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void OnProjectileButtonPressed()
    {
        myTimer.WaitTime += (float)(baseWait * ( level  * 0.25));
        
        this.Disabled = true;

        textOutput.drawSpeed = 0;
        textOutput.Text = "Upgrading Projectiles to Level "+(level+1).ToString();


    


        myTimer.Start();

    }

    public void OnTimerTimeout()
    {
        this.Disabled=false;
        myTimer.Stop();
        level++;
        levelLabel.Text = level.ToString();

        textOutput.drawSpeed = 0;
        textOutput.Text = "Upgrade of Projectiles Completed";

        checkForShipUpgrade();

        
        
        
    }

    public void checkForShipUpgrade()
    {
        double testValue = level / 2;

        if(Math.Round(testValue)>1)
        {
            visibleShip.Visible = false;
            visibleShip = GetNode<Sprite>("/root/Upgrade Panel/Ship/Sprite2");
            visibleShip.Visible = true;
        }

        if (Math.Round(testValue) > 2)
        {
            visibleShip.Visible = false;
            visibleShip = GetNode<Sprite>("/root/Upgrade Panel/Ship/Sprite3");
            visibleShip.Visible = true;
        }

        if (Math.Round(testValue) > 3)
        {
            visibleShip.Visible = false;
            visibleShip = GetNode<Sprite>("/root/Upgrade Panel/Ship/Sprite4");
            visibleShip.Visible = true;
        }



    }
}
