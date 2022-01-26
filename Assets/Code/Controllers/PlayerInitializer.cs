using UnityEngine;

//Нужен чтоб у фабрики вызвать создание плеера и выставить позицию
internal sealed class PlayerInitializer : IStart
{
    private readonly IPlayerFactory _playerFactory;
    private Transform _player;

    public PlayerInitializer(IPlayerFactory playerFactory, Vector2 positionPlayer)
    {
        _playerFactory = playerFactory;
        _player = _playerFactory.CreatePlayer();
        _player.position = positionPlayer;
    }

    public void MyStart()
    {

    }

    public Transform GetPlayer()
    {
        return _player;
    }
}
