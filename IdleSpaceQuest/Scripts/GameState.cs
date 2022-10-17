using Godot;
using System;

public class GameState : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    [Export]
    public int[] techLevels;
    public float[] techTimeLeft;

    [Export]
    public bool[] techUnlocked;

    [Export]
    public int numberOfTechs=4;
    
   
    public override void _Ready()
    {
        
        techLevels=new int[numberOfTechs];
        techTimeLeft=new float[numberOfTechs]; 
        techUnlocked=new bool[numberOfTechs];
        
        
        for (int i = 0; i < techLevels.Length; i++)
        {
            techLevels[i] = 0;
        }

        for (int i = 0; i < techTimeLeft.Length; i++)
        {

        }


        //For setting the disabled flag on the tech upgrade buttons
        techUnlocked[0]=false;
        for (int i = 1; i < numberOfTechs; i++)
        {
            techUnlocked[i] = true;
        }


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
