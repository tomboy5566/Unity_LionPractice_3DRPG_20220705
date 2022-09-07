using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KuanLun
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("血量資料")]
        protected DataHealth dataHealth;
        [SerializeField, Header("血條圖片")]
        private Image healthImage;

        private float hp;
        private Animator ani;
        private string parHurt = "受傷觸發";
        private string parDead = "死亡判定";
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
