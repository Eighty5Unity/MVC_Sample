using UnityEngine;

//В LateUpdate следим за персонажем 
internal sealed class CameraController : ILateUpdate
{
    private readonly Transform _player;
    private readonly Transform _mainCamera;
    private readonly Vector3 _offset;

    public CameraController(Transform player, Transform mainCamera)
    {
        _player = player;
        _mainCamera = mainCamera;
        _offset = _mainCamera.position - _player.position;
    }
    public void MyLateUpdate(float deltaTime)
    {
        _mainCamera.position = _player.position + _offset;
    }
}
