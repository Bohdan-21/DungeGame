using UnityEngine;

public interface ICameraFollow
{
    Camera GameCamera { get; }

    void SetTarget(Transform target);
}