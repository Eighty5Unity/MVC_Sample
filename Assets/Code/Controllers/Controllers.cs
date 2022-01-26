using System.Collections.Generic;

internal sealed class Controllers : IStart, IUpdate, ILateUpdate, IOnDestroy
{
    //Обьявляем списки всех элементов
    private readonly List<IStart> _startControllers;
    private readonly List<IUpdate> _updateControllers;
    private readonly List<ILateUpdate> _lateUpdateControllers;
    private readonly List<IOnDestroy> _onDestroyControllers;

    //В конструкторе выделяем память под списки элементов
    internal Controllers()
    {
        _startControllers = new List<IStart>(8);
        _updateControllers = new List<IUpdate>(8);
        _lateUpdateControllers = new List<ILateUpdate>(8);
        _onDestroyControllers = new List<IOnDestroy>(8);
    }

    //Метод добавления контроллеров с списки
    internal Controllers AddController(IController controller)
    {
        if(controller is IStart startController)
        {
            _startControllers.Add(startController);
        }

        if(controller is IUpdate updateController)
        {
            _updateControllers.Add(updateController);
        }

        if(controller is ILateUpdate lateUpdateController)
        {
            _lateUpdateControllers.Add(lateUpdateController);
        }

        if(controller is IOnDestroy onDestroyController)
        {
            _onDestroyControllers.Add(onDestroyController);
        }

        return this;
    }

    //Проходимся по всем контроллерам из списка и вызываем у них соответствующие методы
    public void MyStart()
    {
        foreach(var controller in _startControllers)
        {
            controller.MyStart();
        }
    }

    public void MyUpdate(float deltaTime)//у всех контроллеров deltaTime единый!
    {
        foreach(var controller in _updateControllers)
        {
            controller.MyUpdate(deltaTime);
        }
    }

    public void MyLateUpdate(float deltaTime)
    {
        foreach(var controller in _lateUpdateControllers)
        {
            controller.MyLateUpdate(deltaTime);
        }
    }

    public void MyOnDestroy()
    {
        foreach(var controller in _onDestroyControllers)
        {
            controller.MyOnDestroy();
        }
    }
}
