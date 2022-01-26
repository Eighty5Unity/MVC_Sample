using UnityEngine;

public sealed class EnemyFactory : IEnemyFactory
{
    private readonly EnemyData _data;

    public EnemyFactory(EnemyData data)
    {
        _data = data;
    }

    public IEnemy CreateEnemy(EnemyType type)
    {
        var enemyProvider = _data.GetEnemy(type);
        return Object.Instantiate(enemyProvider);
    }
}
