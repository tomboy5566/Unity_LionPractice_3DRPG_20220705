using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class EnemyHealth : HealthSystem
    {
        private EnemySystem enemySystem;
        private Material matDissolve;
        private string nameDissolve = "DissolveValue";
        private float maxDissolve = 2f;
        private float minDissolve = -2.5f;

        private RockObjectPool rockObjectPool;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();
            matDissolve = GetComponentsInChildren<Renderer>()[0].material;
            rockObjectPool = FindObjectOfType<RockObjectPool>();
        }

        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            DropItem();
            StartCoroutine(Dissolve());
        }

        private IEnumerator Dissolve()
        {
            while (maxDissolve > minDissolve)
            {
                maxDissolve -= 0.1f;
                matDissolve.SetFloat(nameDissolve, maxDissolve);
                yield return new WaitForSeconds(0.03f);
            }
        }

        private void DropItem()
        {
            float value = Random.value;

            if (value <= dataHealth.dropProbability)
            {
                //Instantiate(dataHealth.dropProp,
                //transform.position + Vector3.up * 3,
                //Quaternion.identity);
                GameObject tempObject = rockObjectPool.GetPoolObject();
                tempObject.transform.position = transform.position + Vector3.up * 3;
            }
        }
    }
}