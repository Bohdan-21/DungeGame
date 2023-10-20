using UnityEngine;

namespace Scripts.Services.InputService
{
    interface IInputService
    {
        bool IsPress(KeyCode key);
        Vector2 Movement();
    }
}