using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data Health", fileName = "Data Health", order = 4)]
    public class DataHealth : ScriptableObject
    {
        [Header("血量"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("是否掉落寶物")]
        public bool isDrop;
        [HideInInspector, Header("寶物預製物")]
        public GameObject dropProp;
        [HideInInspector, Header("寶物掉落機率"), Range(0f, 1f)]
        public float dropProbability;
    }

    [CustomEditor(typeof(DataHealth))]
    public class DataHealthEditor : Editor
    {
        SerializedProperty spIsDrop;
        SerializedProperty spDropProp;
        SerializedProperty spDropProbability;

        private void OnEnable()
        {
            spIsDrop = serializedObject.FindProperty(nameof(DataHealth.isDrop));
            spDropProp = serializedObject.FindProperty(nameof(DataHealth.dropProp));
            spDropProbability = serializedObject.FindProperty(nameof(DataHealth.dropProbability));
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();

            if (spIsDrop.boolValue)
            {
                EditorGUILayout.PropertyField(spDropProp);
                EditorGUILayout.PropertyField(spDropProbability);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }

}