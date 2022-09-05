using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("§ðÀ»¸ê®Æ")]
        private DataAttack dataAttack;

        protected bool canAttack = true;

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
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaOffset),
                dataAttack.attatckAreaSize / 2,
                transform.rotation, dataAttack.layerTarget);
            if (hits.Length > 0)
            {
                print(hits[0].name);
            }
        }

        protected virtual void StopAttack()
        {

        }
    }

}