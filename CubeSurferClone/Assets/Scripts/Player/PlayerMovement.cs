using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        PlayerMovementInput m_MovementInput;
        float m_Speed;
        float m_HorizontalInput;
        Transform m_PlayerTranform;

        public PlayerMovement(float _speed,Transform _transform,PlayerMovementInput _movementInput)
        {
            m_MovementInput = _movementInput;
            m_Speed = _speed;
            m_PlayerTranform = _transform;
        }

        public void Move()
        {
            m_HorizontalInput = m_MovementInput.HorizontalInput();
            m_PlayerTranform.transform.localPosition += new Vector3(m_HorizontalInput, 0) * Time.deltaTime * m_Speed;
            var pos = m_PlayerTranform.transform.localPosition;
            pos.x = Mathf.Clamp(m_PlayerTranform.transform.localPosition.x, -2.0f, 2.0f);
            m_PlayerTranform.transform.localPosition = pos;
        }
    }
}
