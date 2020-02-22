using Godot;
using System;

public class Map : Node2D {
	[Export] int width = 1024 / Tile.SIDE_LENGTH;
	[Export] int height = 640 / Tile.SIDE_LENGTH;
	private PackedScene tileScene = ResourceLoader.Load<PackedScene>("Scenes/gameObjects/Tile.tscn");
	public override void _Ready() {
		for (int i = 0; i < this.width; i++) {
			for (int j = 0; j < this.height; j++) {
				Node2D instance = (Node2D) this.tileScene.Instance();
				instance.Position = new Vector2(i * Tile.SIDE_LENGTH + Tile.SIDE_LENGTH / 2, j * Tile.SIDE_LENGTH + Tile.SIDE_LENGTH / 2);
				this.AddChild(instance);
			}
		}
	}
}
