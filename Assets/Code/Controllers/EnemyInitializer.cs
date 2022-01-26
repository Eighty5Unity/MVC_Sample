using System.Collections.Generic;

public sealed class EnemyInitializer : IStart
{
    private readonly IEnemyFactory _enemyFactory;
    private CompositeMove _enemy;
    private List<IEnemy> _enemies;

    public EnemyInitializer(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        _enemy = new CompositeMove();
        var enemy = _enemyFactory.CreateEnemy(EnemyType.Small);
        _enemy.AddUnit(enemy);
        _enemies = new List<IEnemy> { enemy };
    }

    public void MyStart()
    {
    }

    public IMove GetMoveEnemies()
    {
        return _enemy;
    }

    public IEnumerable<IEnemy> GetEnemies()
    {
        foreach(var enemy in _enemies)
        {
            yield return enemy;
        }
    }
}
