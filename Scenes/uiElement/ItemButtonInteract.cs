using Godot;
using System;

public class ItemButtonInteract : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Tween TweenN;
	// Called when the node enters the scene tree for the first time.
	private AudioStreamPlayer grindsfx;
	public override void _Ready()
	{
		TweenN = GetNode<Tween>("selectionTween");
		grindsfx = GetNode<AudioStreamPlayer>("grind");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private float anchorReturn = 0;
	private float anchorReveal = (float) -0.3;
	private void _on_Button_mouse_entered()
	{
		TweenN.InterpolateProperty(this, "AnchorTop", this.AnchorTop, anchorReveal, 1, Tween.TransitionType.Back, Tween.EaseType.Out);
		if (!TweenN.IsActive())
		{
			grindsfx.Play();
			TweenN.Start();
		}
	}
	private void _on_Button_mouse_exited(){
		TweenN.InterpolateProperty(this, "AnchorTop", this.AnchorTop, anchorReturn,1, Tween.TransitionType.Back, Tween.EaseType.Out);
		if (!TweenN.IsActive())
		{
			TweenN.Start();
		}
	}


}




