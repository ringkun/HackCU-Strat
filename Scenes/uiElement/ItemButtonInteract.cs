using Godot;
using System;

public class ItemButtonInteract : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Tween TweenN;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TweenN = this.GetParent().GetNode<Tween>("selectionTween");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	/*private float anchorReturn = 0;
	public float anchorReveal = -1;
	private void _on_Button_mouse_entered(){
		TweenN.InterpolateProperty( (Control)(this.GetParent()), "AnchorTop", ((Control)this.GetParent()).AnchorTop, anchorReveal,1, Tween.TransitionType.Back, Tween.EaseType.Out);
		GD.Print(((Control)this.GetParent()).AnchorTop);
		TweenN.Start();
	}
	private void _on_Button_mouse_exited(){
		TweenN.InterpolateProperty( (Control)(this.GetParent()), "AnchorTop", ((Control)this.GetParent()).AnchorTop, anchorReturn,1,  Tween.TransitionType.Back, Tween.EaseType.Out);
		GD.Print(((Control)this.GetParent()).AnchorTop);
		TweenN.Start();
	}*/


}


