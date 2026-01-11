using System;
using UnityEngine;

public class OutOfHealthCondition : IGameplayBreakCondition
{
	public event Action Met;

	public OutOfHealthCondition ()
	{
		Player.Died += HandlePlayerDied;
	}

	private void HandlePlayerDied ()
	{
		Met?.Invoke();
	}
}
