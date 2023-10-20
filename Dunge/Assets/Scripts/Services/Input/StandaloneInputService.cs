using UnityEngine;

namespace Scripts.Services.InputService
{
    class StandaloneInputService : IInputService
    {
        private const string VerticalAxisName = "Vertical";
        private const string HorizontalAxisName = "Horizontal";

        public Vector2 Movement() => 
            new Vector2(Input.GetAxis(HorizontalAxisName), Input.GetAxis(VerticalAxisName));

        public bool IsPress(KeyCode key) => 
            Input.GetKeyDown(key);
    }
}
