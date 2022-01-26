using System.IO;
using UnityEngine;

//Тут содержится путь к другим ScriptableObject

[CreateAssetMenu(fileName ="Data", menuName ="Data/Data")]
public sealed class Data : ScriptableObject
{
    [SerializeField] private string _playerDataPath; //Пути к другим ScriptableObject
    [SerializeField] private string _enemyDataPath;
    private PlayerData _player;
    private EnemyData _enemy;

    //Загружаем префаб из Resources
    public PlayerData Player
    {
        get
        {
            if (_player == null)
            {
                _player = Load<PlayerData>(Path.Combine("Data", _playerDataPath));
                
            }
            return _player;
        }
    }

    public EnemyData Enemy
    {
        get
        {
            if(_enemy == null)
            {
                _enemy = Load<EnemyData>(Path.Combine("Data", _enemyDataPath));
            }
            return _enemy;
        }
    }

    //Метод загрузки префабов
    private T Load<T>(string prefabPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(prefabPath, null));
}
