using Godot;
using System;

public partial class LoadingLabel : Label
{
	private int _dotCount = 0;
	[Export] private Timer DotTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DotTimer.Timeout += OnDotTimerTimeout;	
	}

    private void OnDotTimerTimeout()
    {
        _dotCount = (_dotCount +1) % 4;
		Text = "Loading" + new string('.', _dotCount);
    }
}
