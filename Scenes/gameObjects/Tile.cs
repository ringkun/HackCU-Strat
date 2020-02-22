using Godot;
using System;

public class Tile : Node2D
{
	public const int SIDE_LENGTH = 64;
	
	public override void _Ready()
	{
		Sprite sprite = (Sprite) this.GetChildren()[0];
		float scale = (float) (SIDE_LENGTH / Math.Sqrt(sprite.GetRect().Area));
		sprite.Scale = new Vector2(scale, scale);
	}
	
}
