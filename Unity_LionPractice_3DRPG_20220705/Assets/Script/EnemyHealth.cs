using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class EnemyHealth : HealthSystem
    {
        private EnemySystem enemySystem;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();
        }

        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            DropItem();
        }

        private void DropItem()
        {
            float value = Random.value;

            if (value <= dataHealth.dropProbability)
            {
                Instantiate(dataHealth.dropProp,
                    transform.position + Vector3.up * 3,
                    Quaternion.identity);
            }
        }
    }
}