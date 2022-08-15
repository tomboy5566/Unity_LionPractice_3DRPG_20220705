using UnityEngine;

namespace KuanLun
{
    [CreateAssetMenu(menuName ="KuanLun/Data Enemy",fileName ="Data Enemy",order =1)]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 2000)]
        public float hp;
        [Header("�����O"), Range(0, 200)]
        public float attack;
        [Header("�l�ܶZ��"), Range(0, 2000)]
        public float rangeTrack;
        [Header("�����Z��"), Range(0, 10)]
        public float rangeAttack;
        [Header("�����t��"), Range(0, 100)]
        public float speedWalk;
        [Header("�����D����v"), Range(0, 1)]
        public float probilityDrop;
        [Header("�����D��")]
        public GameObject goDrop;
    }
}