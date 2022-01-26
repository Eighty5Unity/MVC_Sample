using System;

public interface IEnemy : IMove
{
    event Action<int> OnTriggerEnterChange;
}
