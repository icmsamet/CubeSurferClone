using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Collectable;

namespace Level
{
    public class CollectEditorWindow : EditorWindow
    {
        static CollectEditorWindow window;
        List<GameObject> collecables;
        #region Variables
        LevelDesignerProperties properties;
        SplineComputer splineComputer;
        Color color = Color.white;
        #endregion

        [MenuItem("Editor/Collect Editor")]
        public static void ShowWindow()
        {
            window = (CollectEditorWindow)GetWindow(typeof(CollectEditorWindow), false, "Collect Editor");
            window.minSize = new Vector2(500, 500);
        }
        private void OnEnable()
        {
            properties = Resources.Load<LevelDesignerProperties>("LevelDesignerProperties");
        }
        void OnGUI()
        {
            collecables = new List<GameObject>();
            if (FindObjectOfType<SplineComputer>())
            {
                splineComputer = FindObjectOfType<SplineComputer>();
                if (!splineComputer.gameObject.GetComponent<Level>())
                {
                    splineComputer.gameObject.AddComponent<Level>();
                }
                foreach (GameObject go in Selection.gameObjects)
                {
                    Collectable.Collectable collectable = go.GetComponent<Collectable.Collectable>();
                    if (collectable != null)
                        collecables.Add(collectable.gameObject);
                }
                CreateCollect();
            }
            else
            {
                GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
                labelStyle.fontSize = 18;
                labelStyle.normal.textColor = Color.red;
                EditorGUILayout.LabelField("There is no Spline", labelStyle);
            }
        }
        void CreateCollect()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Space(15);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(15);
            if (GUILayout.Button("Delete All", GUILayout.Width(150), GUILayout.Height(40)))
            {
                collecables.ForEach(gameObject => DestroyImmediate(gameObject));
                collecables.Clear();
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Create Collect", GUILayout.Width(150), GUILayout.Height(40)))
            {
                var level = FindObjectOfType<Level>();
                Collectable.Collectable collectable = Instantiate(properties.collectable);
                collectable.gameObject.transform.SetParent(level.collectParent.transform);
                collectable.gameObject.name = "Collect " + FindObjectsOfType<Collectable.Collectable>().ToList().Count().ToString();
                collectable.color = color;
                collectable.SetColor();
                Selection.activeGameObject = collectable.gameObject;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(15);
            EditorGUILayout.BeginVertical();
            GUILayout.Space(12.5f);
            color = (Color)EditorGUILayout.ColorField("Chose Collect Color", color, GUILayout.Width(300));
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            CollectableArea();
            EditorGUILayout.EndVertical();
        }
        void CollectableArea()
        {
            if (collecables.Count > 0)
            {
                EditorGUILayout.BeginVertical();
                GUILayout.Space(5);
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(15);
                EditorGUILayout.BeginVertical();
                for (int i = 0; i < collecables.Count; i++)
                {
                    var currentObj = collecables[i].GetComponent<Collectable.Collectable>();
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Width(150));
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Space(5);
                    EditorGUILayout.BeginVertical();
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(15);
                    EditorGUILayout.LabelField(currentObj.name);
                    EditorGUILayout.EndVertical();
                    if (GUILayout.Button("Delete", GUILayout.Width(100), GUILayout.Height(40)))
                    {
                        int index = collecables.FindIndex(x => x == currentObj.gameObject);
                        DestroyImmediate(collecables[index]);
                        collecables.RemoveAt(index);
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(10);
                    currentObj.transform.localPosition = EditorGUILayout.Vector3Field("Position", currentObj.transform.localPosition);
                    Vector3 rotation = currentObj.transform.localRotation.eulerAngles;
                    rotation = EditorGUILayout.Vector3Field("Rotation", rotation);
                    currentObj.transform.localRotation = Quaternion.Euler(rotation);
                    GUILayout.Space(10);
                    currentObj.color = EditorGUILayout.ColorField("Color ", currentObj.color);
                    currentObj.SetColor();
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();
                    GUILayout.Space(5);
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
        }
    }
}

