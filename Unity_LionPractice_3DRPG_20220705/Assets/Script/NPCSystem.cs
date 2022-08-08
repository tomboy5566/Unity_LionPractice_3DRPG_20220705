using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC對話資料")]
        private DataNPC dataNPC;

        private Animator anTip;
        private string parTipFade = "提示觸發";

        private void Awake()
        {
            anTip = GameObject.Find("對話提示底圖").GetComponent<Animator>();
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