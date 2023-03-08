using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    public class CollectableColor
    {
        MeshRenderer meshRenderer;
        public CollectableColor(MeshRenderer _meshRenderer)
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
