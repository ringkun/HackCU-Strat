using Godot;
using System;

public class PlayAsMonster : Node2D
{
	public override void _Ready()
	{
		NetworkedMultiplayerENet peer = new NetworkedMultiplayerENet();
		peer.Connect("peer_connected", this, nameof(this.GoToGame));
		peer.CreateServer(6669, 1);
		this.GetTree().NetworkPeer = peer;
	}

	public void GoToGame(int id)
	{
		GD.Print("Yay");
	}
}
