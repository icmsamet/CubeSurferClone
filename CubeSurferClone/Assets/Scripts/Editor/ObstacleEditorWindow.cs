using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Obstacle;

namespace Level
{
    public class ObstacleEditorWindow : EditorWindow
    {
        static ObstacleEditorWindow window;
        List<GameObject> obstacles;
        #region Variables
        LevelDesignerProperties properties;
        SplineComputer splineComputer;
        ObstacleType type;
        #endregion

        [MenuItem("Editor/Obstacle Editor")]
        public static void ShowWindow()
        {
            window = (ObstacleEditorWindow)GetWindow(typeof(ObstacleEditorWindow), false, "Obstacle Editor");
            window.minSize = new Vector2(500, 500);
        }
        private void OnEnable()
        {
            properties = Resources.Load<LevelDesignerProperties>("LevelDesignerProperties");
        }
        void OnGUI()
        {
            obstacles = new List<GameObject>();
            if (FindObjectOfType<SplineComputer>())
            {
                splineComputer = FindObjectOfType<SplineComputer>();
                if (!splineComputer.gameObject.GetComponent<Level>())
                {
                    splineComputer.gameObject.AddComponent<Level>();
                }
                foreach (GameObject go in Selection.gameObjects)
                {
                    Obstacle.Obstacle obstagle = go.GetComponent<Obstacle.Obstacle>();
                    if (obstagle != null)
                        obstacles.Add(obstagle.gameObject);
                }
                CreateObstacle();
            }
            else
            {
                GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
                labelStyle.fontSize = 18;
                labelStyle.normal.textColor = Color.red;
                EditorGUILayout.LabelField("There is no Spline", labelStyle);
            }
        }
        void CreateObstacle()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Space(15);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(15);
            if (GUILayout.Button("Delete All", GUILayout.Width(150), GUILayout.Height(40)))
            {
                obstacles.ForEach(gameObject => DestroyImmediate(gameObject));
                obstacles.Clear();
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Create Obstacle", GUILayout.Width(150), GUILayout.Height(40)))
            {
                var level = FindObjectOfType<Level>();
                Obstacle.Obstacle obstacle = Instantiate(properties.obstacle);
                obstacle.gameObject.transform.SetParent(level.obstaclesParent.transform);
                obstacle.gameObject.name = "Obstacle " + FindObjectsOfType<Obstacle.Obstacle>().ToList().Count().ToString();
                obstacle.type = type;
                obstacle.ChangeObs();
                Selection.activeGameObject = obstacle.gameObject;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(15);
            EditorGUILayout.BeginVertical();
            GUILayout.Space(12.5f);
            type = (ObstacleType)EditorGUILayout.EnumPopup("Chose Obstagle Type", type, GUILayout.Width(300));
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            ObstacleArea();
            EditorGUILayout.EndVertical();
        }
        void ObstacleArea()
        {
            if (obstacles.Count > 0)
            {
                EditorGUILayout.BeginVertical();
                GUILayout.Space(5);
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(15);
                EditorGUILayout.BeginVertical();
                for (int i = 0; i < obstacles.Count; i++)
                {
                    var currentObj = obstacles[i].GetComponent<Obstacle.Obstacle>();
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
                        int index = obstacles.FindIndex(x => x == currentObj.gameObject);
                        DestroyImmediate(obstacles[index]);
                        obstacles.RemoveAt(index);
                    }
                    EditorGUILayout.EndVertical();
                    GUILayout.Space(10);
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(10);
                    currentObj.transform.localPosition = EditorGUILayout.Vector3Field("Position", currentObj.transform.localPosition);
                    Vector3 rotation = currentObj.transform.localRotation.eulerAngles;
                    rotation = EditorGUILayout.Vector3Field("Rotation", rotation);
                    currentObj.transform.localRotation = Quaternion.Euler(rotation);
                    GUILayout.Space(12.5f);
                    currentObj.color = EditorGUILayout.ColorField("Color ", currentObj.color);
                    currentObj.SetColor();
                    GUILayout.Space(12.5f);
                    currentObj.type = (ObstacleType)EditorGUILayout.EnumPopup("Chose Obstacle Type", currentObj.type, GUILayout.Width(300));
                    currentObj.ChangeObs();
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

