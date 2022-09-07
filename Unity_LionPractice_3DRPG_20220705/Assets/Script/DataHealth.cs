using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data Health", fileName = "Data Health", order = 4)]
    public class DataHealth : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("�O�_�����_��")]
        public bool isDrop;
        [HideInInspector, Header("�_���w�s��")]
        public GameObject dropProp;
        [HideInInspector, Header("�_���������v"), Range(0f, 1f)]
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