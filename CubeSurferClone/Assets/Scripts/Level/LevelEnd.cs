using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using GameManager;

namespace Level
{
    public class LevelEnd : MonoBehaviour
    {
        [SerializeField]LevelDesignerProperties properties;
        [SerializeField] GameSettings settings;

        [Range(1, 10)]
        [OnValueChanged("ChangeStairs")][SerializeField] int stairCount = 1;   
        [Range(1,10)]
        [OnValueChanged("ChangeStairs")][SerializeField] float scaleZ = 1;
        void ChangeStairs()
        {
            properties = Resources.Load<LevelDesignerProperties>("LevelDesignerProperties");
            settings = Resources.Load<GameSettings>("Game Settings");
            //var mesh = transform.root.gameObject;
            var mesh = FindObjectOfType<Level>().gameObject;
            while (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
            for (int i = 0; i < stairCount; i++)
            {
                Stair.Stair stair = Instantiate(properties.stair);
                stair.transform.SetParent(this.transform);
                stair.transform.localScale = new Vector3(GetObjectBoundSizes(mesh.gameObject).x, settings.collectableOffset, scaleZ);
                if (i != 0)
                {
                    var beforeObj = transform.GetChild(i - 1);
                    stair.transform.localPosition = new Vector3(0, GetObjectBoundSizes(stair.gameObject).y+beforeObj.transform.localPosition.y, 
                        GetObjectBoundSizes(stair.gameObject).z + beforeObj.transform.localPosition.z);
                }
                else
                {
                    stair.transform.localPosition = new Vector3(0, GetObjectBoundSizes(stair.gameObject).y/2, GetObjectBoundSizes(stair.gameObject).z/2);
                }
                stair.gameObject.tag = "Stair";
            }
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.gameObject.name = "Platform";
            platform.transform.SetParent(this.transform);
            platform.tag = "Platform";
            var lastObj = transform.GetChild(transform.childCount - 2).gameObject;
            platform.transform.localScale = new Vector3(GetObjectBoundSizes(mesh.gameObject).x*2, settings.collectableOffset, scaleZ*2);
            platform.transform.localPosition = new Vector3(lastObj.transform.localPosition.x, lastObj.transform.localPosition.y,
                 lastObj.transform.localPosition.z + (GetObjectBoundSizes(lastObj).z*1.5f));

        }
        Vector3 GetObjectBoundSizes(GameObject obj)
        {
            var mesh = obj.GetComponent<MeshRenderer>();
            return mesh.bounds.size;
        }
    }
}
