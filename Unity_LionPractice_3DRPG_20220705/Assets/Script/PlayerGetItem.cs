using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KuanLun
{
    public class PlayerGetItem : MonoBehaviour
    {
        private RockObjectPool rockObjectPool;
        private string propRock = "石頭核心碎片";
        private int countRock = 0;
        private int countRockMax = 5;
        private TextMeshProUGUI textCount;

        private NPCSystem npcSystem;

        [SerializeField, Header("完成任務的對話")]
        private DataNPC dataNPC;

        private void Awake()
        {
            //rockObjectPool = FindObjectOfType<RockObjectPool>();
            rockObjectPool = GameObject.Find("物件池碎片").GetComponent<RockObjectPool>();

            textCount = GameObject.Find("碎片數量").GetComponent<TextMeshProUGUI>();
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
            textCount.text = "核心碎片：" + (++countRock) + " / " + countRockMax;
            if (countRock >= countRockMax) npcSystem.dataNPC = dataNPC;
        }
    }
}