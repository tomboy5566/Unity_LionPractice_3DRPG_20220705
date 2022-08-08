using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC��ܸ��")]
        private DataNPC dataNPC;

        private Animator anTip;
        private string parTipFade = "����Ĳ�o";

        private void Awake()
        {
            anTip = GameObject.Find("��ܴ��ܩ���").GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }
        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }
        private void CheckPlayerAndAnimation(string nameIn)
        {
            if (nameIn == "Jammo_LowPoly")
            {
                anTip.SetTrigger(parTipFade);
            }
        }
    }
}