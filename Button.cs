using Godot;
using System;

public class Button : Godot.Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	int width
	int height

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode("Button").Connect("pressed", this, nameof(_OnButtonPressed))
	}
		public void _OnButtonPressed()
	{
		GetNode<MeshInstance2d>("Parent/grid")
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}


private void _on_Button_pressed()
{
	// Replace with function body.
}
