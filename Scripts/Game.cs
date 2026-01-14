using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	[Export] private Timer _spawnTimer;
	[Export] private PackedScene _pipesScene;    



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        _spawnTimer.Timeout += SpawnPipes;
		SignalManager.Instance.OnPlaneDied += GameOver;

        ScoreManager.ResetScore();
		SpawnPipes();
    }

    public override void _ExitTree()
    {
        SignalManager.Instance.OnPlaneDied -= GameOver;
    }

    private void GameOver()
    {
		_spawnTimer.Stop();
    }


    private void SpawnPipes()
    {
        Pipes np = _pipesScene.Instantiate<Pipes>();
        AddChild(np);
		np.GlobalPosition = new Vector2(_spawnLower.GlobalPosition.X, GetSpawnY());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.Q))
        {
            GameManager.LoadMain();
        }    
    }

	public float GetSpawnY()
    {
        return (float)GD.RandRange(_spawnUpper.GlobalPosition.Y, _spawnLower.GlobalPosition.Y);
    }
}
