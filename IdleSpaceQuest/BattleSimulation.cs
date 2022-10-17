using Godot;
using System;

public class BattleSimulation : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    public UpgradeButtons projectile;
    public UpgradeButtons photon;
    public UpgradeButtons quantium;
    public UpgradeButtons plank;

    public Timer battleTimer;

    public ScrollContainer sc;

    public RandomNumberGenerator rng;

    public int completedLevels;
    public int battleTicks;
    public int enemyHitpoints;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        projectile = GetNode<UpgradeButtons>("../ProjectileButton");
        photon= GetNode<UpgradeButtons>("../PhotonButton");
        quantium=GetNode<UpgradeButtons>("../QuantiumButton");
        plank= GetNode<UpgradeButtons>("../PlankButton");
                
        sc =GetNode<ScrollContainer>("/root/UpgradePanel/Panel/ScrollContainer");

        battleTimer = GetNode<Timer>("Timer");

       
        sc.addEntry("Battle Simulation Test");

        
        completedLevels = 0;
        battleTicks = 10;

        rng=new RandomNumberGenerator();

    }


    public void SimulateBattle()
    {
        enemyHitpoints = 10 + (10 * completedLevels);
        battleTicks = 10;
        sc.addEntry("Attaching the enemy");
        battleTimer.Start(1);
    }


    public void battleTick()
    {

        if (battleTicks == 0)
        {
            //No more turns off
           
            sc.addEntry("You Lost !!!");
            battleTimer.Stop();
        }
        else
        {
            //fight a round
            

            if(checkForVicrory())
            {
                
                sc.addEntry("Vicrory");
                completedLevels++;
                battleTimer.Stop();
            }

            battleTicks--;
        }



    }

    public bool checkForVicrory()
    {
        enemyHitpoints -= projectile.level;

        if (enemyHitpoints <= 0)
            return true;
        else
        {
            if (rng.RandfRange(0f, 100f) < 20+completedLevels)
            {
                
                sc.addEntry( "Round ("+(11-battleTicks)+"/10) " + "You Missed: Enemy hitpoints remaining: " + enemyHitpoints.ToString());
                return false;
            }
            else
            {
                
                sc.addEntry("Round ("+(11-battleTicks) + "/10) " + "You Hit: Enemy hitpoints remaining: " + enemyHitpoints.ToString());
                return false;
            }
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
