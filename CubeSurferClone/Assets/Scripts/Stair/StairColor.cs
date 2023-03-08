using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stair
{
    public class StairColor
    {
        MeshRenderer meshRenderer;
        public StairColor(MeshRenderer _meshRenderer)
        {
            meshRenderer = _meshRenderer;
        }
        public void SetColor(Color color)
        {
            if (!meshRenderer.material)
            {
                Material defaultMat = new Material(Shader.Find("Standard"));
                meshRenderer.material = defaultMat;
            }
            meshRenderer.material.color = color;
        }
    }
}
