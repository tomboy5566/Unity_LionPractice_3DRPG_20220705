using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("攻擊資料")]
        private DataAttack dataAttack;
        [SerializeField, Header("攻擊動畫名稱")]
        protected string nameAttackAnimation;

        protected bool canAttack = true;
        protected Animator ani;

        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
        }

        public void StartAttack()
        {
            if (!canAttack) return;
            StartCoroutine(AttackFlow());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = dataAttack.attackAreaColor;
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaOffset),
                transform.rotation, transform.localScale);
            Gizmos.DrawCube(
                Vector3.zero,
                dataAttack.attatckAreaSize);
        }

        private IEnumerator AttackFlow()
        {
            canAttack = false;
            yield return new WaitForSeconds(dataAttack.delayAttack);
            CheckAttackArea();

            yield return new WaitForSeconds(dataAttack.waitAttack);
            canAttack = true;
            StopAttack();
        }

        private void CheckAttackArea()
        {
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName(nameAttackAnimation)) return;
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaOffset),
                dataAttack.attatckAreaSize / 2,
                transform.rotation, dataAttack.layerTarget);
            if (hits.Length > 0)
            {
                hits[0].GetComponent<HealthSystem>().Hurt(dataAttack.attackDamage);
            }
        }

        protected virtual void StopAttack()
        {

        }
    }

}