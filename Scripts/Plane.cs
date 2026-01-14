using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Plane : CharacterBody2D
{

	const float GRAVITY = 950.0f;
	const float POWER = -390.0f;

	[Export] private AnimationPlayer _animationPlayer;
	[Export] private AnimatedSprite2D _planeSprite;
	[Export] private AudioStreamPlayer _engineSound;


	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
    {
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;

		if (Input.IsActionJustPressed("fly")) //user input for jumping(fly)
        {
            velocity.Y = POWER;
			_animationPlayer.Play("power");
        }

        
		Velocity = velocity;
		MoveAndSlide();

		if(IsOnFloor())
        {
            Die();
        }	
    }

	public void Die()
    {
        SetPhysicsProcess(false);
		_planeSprite.Stop();
		_engineSound.Stop();
		//EmitSignal(SignalName.OnPlaneDied); //using signal manager isntead now
		SignalManager.EmitOnPlaneDied();
    }
}
