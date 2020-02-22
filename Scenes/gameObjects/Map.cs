using Godot;
using System;

public class Map : Node2D
{
	private int width = 32;
	private int height = 32;
	private PackedScene tileScene = ResourceLoader.Load<PackedScene>("Scenes/gameObjects/Tile.tscn");
	public override void _Ready() {
		for (int i = 0; i < this.width; i++) {
			for (int j = 0; j < this.height; j++) {
				Node2D instance = (Node2D) this.tileScene.Instance();
				instance.Position = new Vector2(i * 100, j * 100);
				this.AddChild(instance);
			}
		}
	}
}
