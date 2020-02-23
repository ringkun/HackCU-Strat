using Godot;
using System;

public class PlayAsExplorer : Node2D
{
	
	private void onSubmit()
	{
		NetworkedMultiplayerENet peer = new NetworkedMultiplayerENet();
		peer.Connect("peer_connected", this, nameof(this.GoToGame));
		peer.CreateClient(this.GetNode<TextEdit>("TextEdit").Text, 6669);
		this.GetTree().NetworkPeer = peer;
	}

	public void GoToGame(int id)
	{
		GD.Print("yay");
	}

	
}
