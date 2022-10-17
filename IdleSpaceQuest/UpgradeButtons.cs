using Godot;
using System;

public class UpgradeButtons : Button
{
    
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

   
    public Label levelLabel;
    public Label timeoutLabel;
    public Label resourceCostLabel;
   
    public Resource researchResource;
    public WeaponLabel buttonType;
    public ColorRect colorRect;

    public ScrollContainer sc;

    public Timer myTimer;

    [Export]
    public string weaponType;
    [Export]
    public int upgradeCost;
    [Export]
    public int upgradeMultiplier;
    [Export]
    public int level;
    [Export]
    public float baseWait;
    [Export]
    public int techNum;

    public GameState gameState;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        levelLabel = GetNode<Label>("Level");
        buttonType= GetNode<WeaponLabel>("WeaponLabel");
        colorRect = GetNode<ColorRect>("TimeoutRect");
        timeoutLabel = GetNode<Label>("TimeLeft");
        resourceCostLabel = GetNode<Label>("ResourceCost");
        researchResource = GetNode<Resource>("../ResourcePanelBG/"+ weaponType + "Research");

        myTimer = GetNode<Timer>("Timer");
        
        baseWait = 5;

        buttonType.Text = weaponType;

       

        sc = GetNode<ScrollContainer>("/root/UpgradePanel/Panel/ScrollContainer");

       

        gameState = GetNode<GameState>("/root/GameState");

        this.Disabled = gameState.techUnlocked[techNum];

        GD.Print(techNum+" at Level "+level);

        this.level = gameState.techLevels[techNum];

        levelLabel.Text = "Level " + level.ToString();
        resourceCostLabel.Text = "Requires " + upgradeCost.ToString() + " " + weaponType + " Research";

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (myTimer.TimeLeft !=0)
        { 
                colorRect.RectSize = new Vector2(colorRect.RectSize.x, (myTimer.TimeLeft / myTimer.WaitTime) *200);
                timeoutLabel.Text = myTimer.TimeLeft.ToString("0.0")+"s";
        }

        if(researchResource.researchStored>=upgradeCost)
        {
            this.Disabled=false;
        }
        else
        {
            this.Disabled=true;
        }
    }

    public void OnUpgradeButtonPressed()
    {

        researchResource.researchStored -= upgradeCost;
        upgradeCost += upgradeMultiplier+level;
        resourceCostLabel.Text = "Requires "+upgradeCost.ToString() +" " +weaponType+ " Research";

        myTimer.WaitTime += (float)(baseWait * (level * 0.25));

        this.Disabled = true;


       
        sc.addEntry("Upgrading "+weaponType+" Weapons To Level " + (level + 1).ToString());

        

        myTimer.Start();

    }

    public void OnTimerTimeout()
    {
        
        myTimer.Stop();
        level++;
        levelLabel.Text = "Level "+level.ToString();

        gameState.techLevels[techNum] = level;
        
        sc.addEntry("Upgrade Of " + weaponType + " Weapons Completed");
        timeoutLabel.Text = "";


    }

   
}