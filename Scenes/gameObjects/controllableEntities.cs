using Godot;
using System;
using System.Security;

public class controllableEntities : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
/*Current Player Position*/
	private Vector2 position;
/*Number of Stone in possesion*/
	private int stones;
/*How many moves per turn the player has*/
	private int walkspeed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
/*Return Current Position*/
	public Vector2 getCoord(){
		return position;
	}
	private bool validPos(int x, int y)
	{
		bool b = false;
		return b;
	}

	public bool setCoord(int x, int y)
	{
		bool b = false;
		if (validPos(x, y))
		{
			this.Position = new Vector2(x, y);
		}

		return b;
	}

	private int isWall(int x, int y)
	{
		int b = 1;
		return b;
	}

	public void examine()
	{
		Vector2 currPos = getCoord();
		int[] arr = {1,0,-1,0};
		int wallCount = 0;
		for (int i = 0; i < 4; i++)
			wallCount = wallCount + isWall((int)currPos.x + arr[i], (int)currPos.y + arr[(i + 1) % 3]);
		{
		GD.Print("There are "+wallCount+" walls surrounding you.");	
		}				
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
