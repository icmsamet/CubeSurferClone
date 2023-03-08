using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleColor
    {
        MeshRenderer[] meshRenderer;
        public ObstacleColor(MeshRenderer[] _meshRenderer)
        {
            meshRenderer = _meshRenderer;
        }
        public void SetColor(Color color)
        {
            foreach (var item in meshRenderer)
            {
                if (!item.material)
                {
                    Material defaultMat = new Material(Shader.Find("Standard"));
                    item.material = defaultMat;
                }
                item.material.color = color;
            }
        }
    }
}
