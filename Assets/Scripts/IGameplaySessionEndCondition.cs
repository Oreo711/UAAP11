using System;

public interface IGameplaySessionEndCondition : IDisposable
{
    public event Action Met;

    void Initialize ();
}
