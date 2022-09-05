using UnityEngine;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data Attack", fileName = "Data Attack", order = 3)]
    public class DataAttack : ScriptableObject
    {
        [Header("攻擊力"), Range(0, 1000)]
        public float attackDamage;
        [Header("攻擊區域設定")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attatckAreaSize = Vector3.one;
        public Vector3 attackAreaOffset;
        [Header("攻擊目標圖層")]
        public LayerMask layerTarget;
        [Header("攻擊延遲時間"), Range(0, 3)]
        public float delayAttack = 1.5f;
        [Header("攻擊動畫")]
        public AnimationClip animationAttack;

        public float waitAttack => animationAttack.length - delayAttack;
    }
}