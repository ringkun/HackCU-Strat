using Godot;
using System;

public class ItemButtonInteract : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{		GD.Print(this.AnchorTop);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }//onready var TweenN = get_node("Tween");
	private float anchorReturn = 0;
	public float anchorReveal = 20;
	private void _on_Button_focus_entered(){

		//    TweenN.interpolate_property(self, "anchor", getpos(), anchorReveal, Tween.TRANS_BACK, Tween.EASEOUT)
	}
	private void _on_Button_focus_exited()
	{
		// Replace with function body.
	}


}


