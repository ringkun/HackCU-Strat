using Godot;
using System;
/*Note from William
 Decided to do some work on the tiles. The added textures onto the tiles
 */

public class Tile : Node2D
{
	public const int SIDE_LENGTH = 64;
/*Modify "arr" for different textures*/
	private string[] arr =
	{
		"res://Assets/Images/stonetex1.png",
		"res://Assets/Images/stonetex2.png",
		"res://Assets/Images/stonetex3.png",
		"res://Assets/Images/stonetex4.png",
		"res://Assets/Images/stonetex5.png"
	};
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	public override void _Ready()
	{
		Sprite sprite = (Sprite) this.GetChildren()[0];
		float scale = (float) (SIDE_LENGTH / Math.Sqrt(sprite.GetRect().Area));
		sprite.Scale = new Vector2(scale, scale);
/*I did the honor of giving each tile a random orientation as well as texture*/
		rng.Randomize();
		int r = rng.RandiRange(0, arr.Length-1);
		sprite.Texture = (Texture) ResourceLoader.Load(arr[r]);
		rng.Randomize();
		sprite.FlipH = rng.RandiRange(0, 1)==1;
		rng.Randomize();
		sprite.FlipV = rng.RandiRange(0, 1)==1;
		rng.Randomize();
		sprite.Rotation = rng.RandiRange(0, 3) * (float)Math.PI/2;
	}
	
}
