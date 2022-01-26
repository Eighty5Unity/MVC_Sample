using UnityEngine;

//Класс инициализации всей игры, при большой игре лучше разбивать на много классов
internal sealed class GameInitialization 
{
    public GameInitialization(Controllers controllers, Data data)
    {
        Camera camera = Camera.main;
        var inputInitialization = new InputInitialization();
        var playerModel = new PlayerModel(data.Player.Sprite, data.Player.Speed, data.Player.Position, data.Player.Name);
        var playerFactory = new PlayerFactory(playerModel);
        var playerInitializer = new PlayerInitializer(playerFactory, playerModel.Position);
        var enemyFactory = new EnemyFactory(data.Enemy);
        var enemyInitialization = new EnemyInitializer(enemyFactory);

        controllers.AddController(inputInitialization); // собрали инпут
        controllers.AddController(new InputController(inputInitialization.GetInput()));// нажали
        controllers.AddController(new MoveController(inputInitialization.GetInput(), playerInitializer.GetPlayer(), playerModel));// приняли то что нажали
        controllers.AddController(playerInitializer);
        controllers.AddController(new CameraInitializer(camera.transform, playerModel.Position));
        controllers.AddController(new CameraController(playerInitializer.GetPlayer(), camera.transform));
        controllers.AddController(enemyInitialization);
        controllers.AddController(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitializer.GetPlayer()));
        controllers.AddController(new EndGameController(enemyInitialization.GetEnemies(), playerInitializer.GetPlayer().gameObject.GetInstanceID()));
    }
}
