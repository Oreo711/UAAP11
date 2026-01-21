using System;


public class OutOfHealthCondition : IGameplaySessionEndCondition
{
	public event Action Met;

	public void Initialize ()
	{
		Player.Died += HandlePlayerDied;
	}

	private void HandlePlayerDied ()
	{
		Met?.Invoke();
	}

	public void Dispose ()
	{
		Player.Died -= HandlePlayerDied;
	}
}
