using System.Collections.Generic;
using UnityEngine;

internal sealed class EndGameController : IStart, IOnDestroy
{
    private readonly IEnumerable<IEnemy> _getEnemies;
    private readonly int _playerID;

    public EndGameController(IEnumerable<IEnemy> getEnemies, int playerID)
    {
        _getEnemies = getEnemies;
        _playerID = playerID;
    }

    public void MyStart()
    {
        foreach(var enemy in _getEnemies)
        {
            enemy.OnTriggerEnterChange += EnemyOnTriggerEnterChange;
        }
    }

    private void EnemyOnTriggerEnterChange(int value)
    {
        if(value == _playerID)
        {
            Debug.Log(22);
        }
    }

    public void MyOnDestroy()
    {
        foreach (var enemy in _getEnemies)
        {
            enemy.OnTriggerEnterChange -= EnemyOnTriggerEnterChange;
        }
    }
}
