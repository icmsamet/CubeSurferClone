using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Level
{
    [ExecuteInEditMode]
    public class Level : MonoBehaviour
    { 
        public static Level instance { get; private set; }
        public GameObject obstaclesParent;
        public GameObject collectParent;
        [OnValueChanged("SetLevelID")]
        public int levelID = 0;
        private void Awake()
        {
            if (!instance)
                instance = this;
        }
        private void Start()
        {
            SetLevelID();
            if(!obstaclesParent || !collectParent)
            {
                while (transform.childCount != 0)
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);
                }
                obstaclesParent = new GameObject("Obstacles");
                obstaclesParent.transform.SetParent(this.transform);
                collectParent = new GameObject("Collects");
                collectParent.transform.SetParent(this.transform);
            }
        }
        void SetLevelID()
        {
            levelID = Mathf.Clamp(levelID, 0, 100);
            gameObject.name = "Level " + levelID;
        }

        [Button("Add Level End")]
        void AddLevelEnd()
        {
            var levelEnd = FindObjectOfType<LevelEnd>();
            if (!levelEnd)
            {
                LevelDesignerProperties levelProp = Resources.Load<LevelDesignerProperties>("LevelDesignerProperties");
                levelEnd = Instantiate(levelProp.levelEnd);
                levelEnd.gameObject.name = "Level End";
                levelEnd.gameObject.transform.SetParent(this.transform);
                var mesh = GetComponent<MeshRenderer>();
                levelEnd.gameObject.transform.localPosition = new Vector3(0, 0, -mesh.bounds.size.z);
                levelEnd.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        [Button("Save Prefab")]
        void SaveLevelPrefab()
        {
            LevelsScriptableObject levels = Resources.Load<LevelsScriptableObject>("Levels");
            string levelPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Prefabs/Levels/" + this.gameObject.name + ".prefab");
            GameObject levelPrefab = PrefabUtility.SaveAsPrefabAsset(this.gameObject, levelPath);
            Properties prop = new Properties { levelID = levelID, prefab = levelPrefab };
            levels.properties.Add(prop);
        }
    }
}

