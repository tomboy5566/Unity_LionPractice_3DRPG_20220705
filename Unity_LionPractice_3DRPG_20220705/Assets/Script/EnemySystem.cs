using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KuanLun
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("¼Ä¤H¸ê®Æ")]
        private DataEnemy dataEnemy;

        private Animator ani;
        private NavMeshAgent nma;
        private Vector3 v3TargetPosition = new Vector3(25, 0, 41);

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = dataEnemy.speedWalk;
        }
        private void Update()
        {
            Wander();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangeTrack);
            Gizmos.color = new Color(1, 0.2f, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangeAttack);
        }
        private void Wander()
        {
            nma.SetDestination(v3TargetPosition);
        }
    }
}

