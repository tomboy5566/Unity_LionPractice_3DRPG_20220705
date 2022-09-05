using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KuanLun
{
    public class EnemySystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("敵人資料")]
        private DataEnemy dataEnemy;
        [SerializeField]
        private StateEnemy stateEnemy;

        private Animator ani;
        private NavMeshAgent nma;
        private Vector3 v3TargetPosition;
        private string parWalk = "走路觸發";
        private float timerIdle;
        private float timerAttack;
        private string parAttack = "攻擊觸發";
        private EnemyAttack enemyAttack;
        #endregion

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            enemyAttack = GetComponent<EnemyAttack>();
            nma.speed = dataEnemy.speedWalk;
        }
        private void Update()
        {
            StateSwitcher();
            CheckTargetInTrackRange();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangeTrack);
            Gizmos.color = new Color(1, 0.2f, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, dataEnemy.rangeAttack);
            Gizmos.color = new Color(1, 0.2f, 0.3f, 1);
            Gizmos.DrawSphere(v3TargetPosition, 0.3f);
        }
        private void Wander()
        {
            if (nma.remainingDistance == 0)
            {
                v3TargetPosition = transform.position + Random.insideUnitSphere * dataEnemy.rangeTrack;
                v3TargetPosition.y = transform.position.y;
            }
            nma.SetDestination(v3TargetPosition);
            ani.SetBool(parWalk, nma.velocity.magnitude > 0.1f);
        }
        private void Idle()
        {
            nma.velocity = Vector3.zero;
            ani.SetBool(parWalk, false);
            timerIdle += Time.deltaTime;

            float r = Random.Range(dataEnemy.timeIdleRange.x, dataEnemy.timeIdleRange.y);
            if (timerIdle >= r)
            {
                timerIdle = 0;
                stateEnemy = StateEnemy.Wander;
            }
        }
        private void Track()
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
            {
                nma.velocity = Vector3.zero;
            }

            nma.SetDestination(v3TargetPosition);
            ani.SetBool(parWalk, true);
            ani.ResetTrigger(parAttack);

            if (Vector3.Distance(transform.position, v3TargetPosition) <= dataEnemy.rangeAttack)
            {
                stateEnemy = StateEnemy.Attack;
            }
            else
            {
                timerAttack = dataEnemy.intervalAttack;
            }
        }
        private void Attack()
        {
            ani.SetBool(parWalk, false);
            nma.velocity = Vector3.zero;
            if (timerAttack < dataEnemy.intervalAttack)
            {
                timerAttack += Time.deltaTime;
            }
            else
            {
                ani.SetTrigger(parAttack);
                timerAttack = 0;
                enemyAttack.StartAttack();
                stateEnemy = StateEnemy.Track;
            }
        }
        private void StateSwitcher()
        {
            switch (stateEnemy)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Wander:
                    Wander();
                    break;
                case StateEnemy.Track:
                    Track();
                    break;
                case StateEnemy.Attack:
                    Attack();
                    break;
            }
        }
        private void CheckTargetInTrackRange()
        {

            Collider[] hits = Physics.OverlapSphere(transform.position, dataEnemy.rangeTrack, dataEnemy.layerTarget);
            if (hits.Length > 0)
            {
                v3TargetPosition = hits[0].transform.position;
                if (stateEnemy == StateEnemy.Attack) return;
                stateEnemy = StateEnemy.Track;
            }
            else
            {
                stateEnemy = StateEnemy.Wander;
            }
        }
    }
}

