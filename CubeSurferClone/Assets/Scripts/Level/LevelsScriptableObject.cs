using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

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
        [OnValueChanged("CheckEmptys")]
        public List<Properties> properties = new List<Properties>();

        void CheckEmptys()
        {
            properties.RemoveAll(element => element.prefab == null);
        }
    }
}
