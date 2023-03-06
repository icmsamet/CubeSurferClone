using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [System.Serializable]
    public class Properties
    {
        public int levelID;
        public GameObject prefab;
    }
    [CreateAssetMenu(fileName = "Levels",menuName = "New Levels")]
    public class LevelsScriptableObject : ScriptableObject
    {
        public List<Properties> properties = new List<Properties>();
    }
}
