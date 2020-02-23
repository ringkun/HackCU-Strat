using Godot;
using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using MazeGeneration;

/*Graciously stolen from Rosetta Code*/
namespace MazeGeneration
{
	public static class Extensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
		{
			var e = source.ToArray();
			for (var i = e.Length - 1; i >= 0; i--)
			{
				var swapIndex = rng.Next(i + 1);
				yield return e[swapIndex];
				e[swapIndex] = e[i];
			}
		}
 
		public static CellState OppositeWall(this CellState orig)
		{
			return (CellState)(((int) orig >> 2) | ((int) orig << 2)) & CellState.Initial;
		}
 
		public static bool HasFlag(this CellState cs,CellState flag)
		{
			return ((int)cs & (int)flag) != 0;
		}
	}
 
	[Flags]
	public enum CellState
	{
		Top = 1,
		Right = 2,
		Bottom = 4,
		Left = 8,
		Visited = 128,
		Initial = Top | Right | Bottom | Left,
	}

	public struct Point
	{
		public int X;
		public int Y;
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
	public struct RemoveWallAction
	{
		public Point Neighbour;
		public CellState Wall;
	}
	public class Maze
	{
		private readonly CellState[,] _cells;
		private readonly int _width;
		private readonly int _height;
		private readonly Random _rng;
		
		public Maze(int width, int height)
		{
			_width = width;
			_height = height;
			_cells = new CellState[width, height];
			for(var x=0; x<width; x++)
				for(var y=0; y<height; y++)
					_cells[x, y] = CellState.Initial;
			_rng = new Random();
			VisitCell(_rng.Next(width), _rng.Next(height));
		}
 
		public CellState this[int x, int y]
		{
			get { return _cells[x,y]; }
			set { _cells[x,y] = value; }
		}
 
		public IEnumerable<RemoveWallAction> GetNeighbours(Point p)
		{
			if (p.X > 0) yield return new RemoveWallAction {Neighbour = new Point(p.X - 1, p.Y), Wall = CellState.Left};
			if (p.Y > 0) yield return new RemoveWallAction {Neighbour = new Point(p.X, p.Y - 1), Wall = CellState.Top};
			if (p.X < _width-1) yield return new RemoveWallAction {Neighbour = new Point(p.X + 1, p.Y), Wall = CellState.Right};
			if (p.Y < _height-1) yield return new RemoveWallAction {Neighbour = new Point(p.X, p.Y + 1), Wall = CellState.Bottom};
		}
 
		public void VisitCell(int x, int y)
		{
			this[x,y] |= CellState.Visited;
			foreach (var p in GetNeighbours(new Point(x, y)).Shuffle(_rng).Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
			{
				this[x, y] -= p.Wall;
				this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
				VisitCell(p.Neighbour.X, p.Neighbour.Y);
			}
		}
 
		public void Display()
		{
			var firstLine = string.Empty;
			for (var y = 0; y < _height; y++)
			{
				var sbTop = new StringBuilder();
				var sbMid = new StringBuilder();
				for (var x = 0; x < _width; x++)
				{
					sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "+--" : "+  ");
					sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "|  " : "   ");
				}
				if (firstLine == string.Empty)
					firstLine = sbTop.ToString();
				Debug.WriteLine(sbTop + "+");
				Debug.WriteLine(sbMid + "|");
			}
			Debug.WriteLine(firstLine);
		}
	}
 
	/*class Program
	{
		static void Main(string[] args)
		{
			var maze = new Maze(20, 20);
			maze.Display();
		}
	}*/
}

public class Map : Node2D
{
	/*
	[Export] int width = 1024 / Tile.SIDE_LENGTH;
	[Export] int height = 640 / Tile.SIDE_LENGTH;
	*/
	[Export] int width = 8;
	[Export] int height = 5;

	private PackedScene tileScene = ResourceLoader.Load<PackedScene>("Scenes/gameObjects/Tile.tscn");
	private PackedScene wallt = ResourceLoader.Load<PackedScene>("res://Scenes/gameObjects/wallT.tscn");
	private PackedScene walll = ResourceLoader.Load<PackedScene>("res://Scenes/gameObjects/wallL.tscn");
	public override void _Ready() {
		Maze mazeLayout = new Maze(this.width, this.height);
		for (int j = 0; j < this.height; j++) {
			for (int i = 0; i < this.width; i++) {
				Node2D instance = (Node2D) this.tileScene.Instance();
				instance.Position = new Vector2(i * Tile.SIDE_LENGTH + Tile.SIDE_LENGTH / 2, j * Tile.SIDE_LENGTH + Tile.SIDE_LENGTH / 2);
				this.AddChild(instance);
/*Add walls*/
				 bool top = mazeLayout[i, j].HasFlag(CellState.Top);
				 bool left = mazeLayout[i, j].HasFlag(CellState.Left);
				 GD.Print(mazeLayout[i,j]+","+ i +","+j+","+top+","+left);
				 
				 if (top)
				 {
					 Node2D walltInstance = (Node2D) this.wallt.Instance();
					 walltInstance.Position = new Vector2(i * Tile.SIDE_LENGTH+Tile.SIDE_LENGTH, j * Tile.SIDE_LENGTH+Tile.SIDE_LENGTH);
					 this.AddChild(walltInstance);
				 }
				 if (left)
				 {
					 Node2D walllInstance = (Node2D) this.walll.Instance();
					 walllInstance.Position = new Vector2(i * Tile.SIDE_LENGTH+Tile.SIDE_LENGTH, j * Tile.SIDE_LENGTH+Tile.SIDE_LENGTH);
					 this.AddChild(walllInstance);
				 }
			}
		}
		mazeLayout.Display();

	}
}
