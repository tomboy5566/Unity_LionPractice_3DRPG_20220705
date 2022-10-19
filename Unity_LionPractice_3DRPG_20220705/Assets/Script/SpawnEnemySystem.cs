using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    [DefaultExecutionOrder(200)]
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField, Header("重新生成時間範圍")]
        private Vector2 rangeRespawn = new Vector2(2, 5);

        private GolemObjectPool golemObjectPool;
        private GameObject enemyObject;

        private void Awake()
        {
            golemObjectPool = GameObject.Find("物件池哥雷姆").GetComponent<GolemObjectPool>();
            Spawn();
        }

        private void Spawn()
        {
            enemyObject = golemObjectPool.GetPoolObject();
            enemyObject.transform.position = transform.position;

            enemyObject.GetComponent<EnemyHealth>().onDead = EnemyDead;
        }

        private void EnemyDead()
        {
            golemObjectPool.ReleasePoolObject(enemyObject);

            float randomTime = Random.Range(rangeRespawn.x, rangeRespawn.y);
            Invoke("Spawn", randomTime);
        }
    }
}