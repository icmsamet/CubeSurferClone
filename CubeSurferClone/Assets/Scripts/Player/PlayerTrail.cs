using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTrail
    {
        TrailRenderer trail;
        public PlayerTrail(TrailRenderer _trail)
        {
            trail = _trail;
        }
        public void SetColor(Color color)
        {
            trail.startColor = color;
            trail.endColor = color;
        }
    }
}
