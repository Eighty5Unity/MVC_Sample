using UnityEngine;

//Построение классов для считывания данных в зависимости от платформы
internal sealed class InputInitialization : IStart
{
    private IUserInputProxy _pcInputHorizontal;
    private IUserInputProxy _pcInputVertical;

    public InputInitialization()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            // Логика для других платформ
            return;
        }

        _pcInputHorizontal = new PCInputHorizontal();
        _pcInputVertical = new PCInputVertical();
    }

    public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
    {
        (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal, _pcInputVertical);
        return result;
    }

    public void MyStart()
    {
    }
}
