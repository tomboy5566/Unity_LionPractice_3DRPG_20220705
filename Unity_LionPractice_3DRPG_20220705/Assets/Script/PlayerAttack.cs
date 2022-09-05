using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class PlayerAttack : AttackSystem
    {
        private Animator ani;
        private ThirdPersonController tpc;

        private string parAttack = "§ðÀ»Ä²µo";

        private void Awake()
        {
            ani = GetComponent<Animator>();
            tpc = GetComponent<ThirdPersonController>();
        }

        private void Update()
        {
            AttackInput();
        }

        private void AttackInput()
        {
            if (!canAttack) return;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tpc.enabled = false;
                ani.SetTrigger(parAttack);
                StartAttack();
            }
        }
        protected override void StopAttack()
        {
            tpc.enabled = true;
        }
    }

}