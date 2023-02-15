using UnityEngine;

namespace Player
{
    public class PlayerMovementInput
    {
        DynamicJoystick m_DynamicJoystick;

        public PlayerMovementInput(DynamicJoystick _dynamicJoystick)
        {
            m_DynamicJoystick = _dynamicJoystick;
        }

        public float HorizontalInput()
        {
            return m_DynamicJoystick.Horizontal;
        }
    }
}
