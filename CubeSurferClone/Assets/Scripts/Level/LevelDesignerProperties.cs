using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "New Level Designer Properties",menuName = "Level Designer Properties")]
    public class LevelDesignerProperties : ScriptableObject
    {
        public Obstacle.Obstacle obstacle;
        public Collectable.Collectable collectable;
        public LevelEnd levelEnd;
        public Stair.Stair stair;
        public Material collectableMaterial;
        public Material obstacleMaterial;
        public Material stairMaterial;
    }
}
