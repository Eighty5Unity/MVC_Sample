using UnityEngine;

//Точка входа в игру. Тут содержатся все стартовые элементы

public sealed class GameStarter : MonoBehaviour
{
    [SerializeField] private Data _data;
    private Controllers _controllers;


    private void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _data);
        _controllers.MyStart();
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.MyUpdate(deltaTime);
    }

    private void LateUpdate()
    {
        var deltaTime = Time.deltaTime;
        _controllers.MyLateUpdate(deltaTime);
    }

    private void OnDestroy()
    {
        _controllers.MyOnDestroy();
    }
}
