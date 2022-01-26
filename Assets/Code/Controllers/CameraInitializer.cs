using UnityEngine;

internal sealed class CameraInitializer : IStart
{
    private readonly Transform _camera;
    private readonly Vector2 _positionPlayer;

    public CameraInitializer(Transform camera, Vector2 positionPlayer)
    {
        _camera = camera;
        _positionPlayer = positionPlayer;
    }

    public void MyStart()
    {
        _camera.position = new Vector3(_positionPlayer.x, _positionPlayer.y, _camera.position.z);
    }
}
