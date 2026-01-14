using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Label _scoreLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        SignalManager.Instance.OnScored += OnScored;
    }

	private void OnScored()
    {
        _scoreLabel.Text = $"{ScoreManager.GetScore():0}";
    }

    public override void _ExitTree()
    {
        SignalManager.Instance.OnScored -= OnScored;
    }

}
