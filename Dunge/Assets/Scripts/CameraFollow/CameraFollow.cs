using Scripts.Services.ControlButtonService;
using Scripts.Services.InputService;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour, ICameraFollow
{
    private KeyCode ZoomOutButton;
    private KeyCode ZoomInButton;
    private KeyCode RotateToLeftButton;
    private KeyCode RotateToRightButton;

    [SerializeField] private Camera _gameCamera;

    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _rotationAngleY;
    [SerializeField] private float _speedRotateYAxis;

    [SerializeField] private float _offsetY;
    [SerializeField] private float _distance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _timeForLerp = 0.15f;

    private Transform _target;
    private IInputService _inputService;

    [Inject]
    private void Construct(IInputService inputService, IControlButtonService controlButtonService)
    {
        _inputService = inputService;

        ZoomInButton = controlButtonService.ControlButtons.CameraControlButtons.ZoomInButton;
        ZoomOutButton = controlButtonService.ControlButtons.CameraControlButtons.ZoomOutButton;

        RotateToLeftButton = controlButtonService.ControlButtons.CameraControlButtons.RotateToLeftButton;
        RotateToRightButton = controlButtonService.ControlButtons.CameraControlButtons.RotateToRightButton;
    }

    public Camera GameCamera { get => _gameCamera; }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (_inputService.IsPress(ZoomOutButton) && _distance < _maxDistance)
                _distance++;
            else if (_inputService.IsPress(ZoomInButton) && _distance > _minDistance)
                _distance--;
            else if (_inputService.IsPress(RotateToLeftButton))
                _rotationAngleY -= _speedRotateYAxis;
            else if (_inputService.IsPress(RotateToRightButton))
                _rotationAngleY += _speedRotateYAxis;
        }
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        Quaternion rotation = Quaternion.Euler(_rotationAngleX, _rotationAngleY, 0);
        Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();


        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _timeForLerp);
        transform.position = Vector3.Lerp(transform.position, position, _timeForLerp);
    }

    private Vector3 FollowingPointPosition()
    {
        Vector3 followingPosition = _target.position;
        followingPosition.y += _offsetY;

        return followingPosition;
    }
}
