using Godot;
using System;

public class Menu : Control {
	
	private void onPlayAsMonster() {
		this.GetTree().ChangeScene("Scenes/uiElement/PlayAsMonster.tscn");
	}

	private void onPlayAsExplorer() {
		this.GetTree().ChangeScene("Scenes/uiElement/PlayAsExplorer.tscn");
	}
	
	private void GoToMap() {
		this.GetTree().ChangeScene("Scenes/gameObjects/Map.tscn");
	}
	
}
