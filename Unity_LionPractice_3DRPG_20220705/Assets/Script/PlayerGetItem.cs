using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KuanLun
{
    public class PlayerGetItem : MonoBehaviour
    {
        private RockObjectPool rockObjectPool;
        private string propRock = "���Y�֤߸H��";
        private int countRock = 0;
        private int countRockMax = 5;
        private TextMeshProUGUI textCount;

        private NPCSystem npcSystem;

        [SerializeField, Header("�������Ȫ����")]
        private DataNPC dataNPC;

        private void Awake()
        {
            //rockObjectPool = FindObjectOfType<RockObjectPool>();
            rockObjectPool = GameObject.Find("������H��").GetComponent<RockObjectPool>();

            textCount = GameObject.Find("�H���ƶq").GetComponent<TextMeshProUGUI>();
            npcSystem = GameObject.Find("Fox").GetComponent<NPCSystem>();
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propRock))
            {
                rockObjectPool.ReleasePoolObject(hit.gameObject);
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            textCount.text = "�֤߸H���G" + (++countRock) + " / " + countRockMax;
            if (countRock >= countRockMax) npcSystem.dataNPC = dataNPC;
        }
    }
}