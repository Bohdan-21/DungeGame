using Scripts.Player;
using Scripts.Services.InputService;
using Scripts.StaticData.ControlButton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    private KeyCode ZoomOutButton;
    private KeyCode ZoomInButton;
    private KeyCode RotateToLeftButton;
    private KeyCode RotateToRightButton;

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
    private void Construct(PlayerBehaviour player, IInputService inputService, ControlButtons controlButtons)
    {
        _target = player.transform;
        _inputService = inputService;

        ZoomInButton = controlButtons.CameraControlButtons.ZoomInButton;
        ZoomOutButton = controlButtons.CameraControlButtons.ZoomOutButton;

        RotateToLeftButton = controlButtons.CameraControlButtons.RotateToLeftButton;
        RotateToRightButton = controlButtons.CameraControlButtons.RotateToRightButton;
    }

    private void Update()
    {
        if (_inputService.IsPress(ZoomOutButton) && _distance < _maxDistance)
            _distance++;
        else if (_inputService.IsPress(ZoomInButton) && _distance > _minDistance)
            _distance--;
        else if (_inputService.IsPress(RotateToLeftButton))
            _rotationAngleY -= _speedRotateYAxis;
        else if(_inputService.IsPress(RotateToRightButton))
            _rotationAngleY += _speedRotateYAxis;
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
