using UnityEngine;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data Attack", fileName = "Data Attack", order = 3)]
    public class DataAttack : ScriptableObject
    {
        [Header("�����O"), Range(0, 1000)]
        public float attackDamage;
        [Header("�����ϰ�]�w")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attatckAreaSize = Vector3.one;
        public Vector3 attackAreaOffset;
        [Header("�����ؼйϼh")]
        public LayerMask layerTarget;
        [Header("��������ɶ�"), Range(0, 3)]
        public float delayAttack = 1.5f;
        [Header("�����ʵe")]
        public AnimationClip animationAttack;

        public float waitAttack => animationAttack.length - delayAttack;
    }
}