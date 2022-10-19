using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KuanLun
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("��q���")]
        protected DataHealth dataHealth;
        [SerializeField, Header("����Ϥ�")]
        protected Image healthImage;

        protected float hp;
        private Animator ani;
        private string parHurt = "����Ĳ�o";
        private string parDead = "���`�P�w";
        private AttackSystem attackSystem;

        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
            hp = dataHealth.hp;
            attackSystem = GetComponent<AttackSystem>();
        }

        public void Hurt(float damage)
        {
            hp -= damage;
            ani.SetTrigger(parHurt);

            if (hp <= 0) Dead();
            healthImage.fillAmount = hp / dataHealth.hpMax;
        }

        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(parDead, true);
            attackSystem.enabled = false;
        }
    }
}
