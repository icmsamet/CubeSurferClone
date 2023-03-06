using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level
{
    public class LevelLoader
    {
        public GameObject level(int index)
        {
            LevelsScriptableObject levels = Resources.Load<LevelsScriptableObject>("Levels");
            GameObject selectedLevelPrefab = levels.properties
            .Where(e => e.levelID == index)
            .Select(e => e.prefab)
            .FirstOrDefault();
            return selectedLevelPrefab;
        }
    }
}
