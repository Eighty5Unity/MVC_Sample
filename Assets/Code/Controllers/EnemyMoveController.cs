using UnityEngine;

public sealed class EnemyMoveController : IUpdate
{
    private readonly IMove _move;
    private readonly Transform _target;

    public EnemyMoveController(IMove move, Transform target)
    {
        _move = move;
        _target = target;
    }

    public void MyUpdate(float deltaTime)
    {
        _move.Move(_target.localPosition);
    }
}
