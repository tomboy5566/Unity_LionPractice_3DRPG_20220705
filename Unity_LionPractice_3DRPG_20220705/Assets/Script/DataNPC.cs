using UnityEngine;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data NPC", fileName = "Data NPC", order = 2)]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC �W��")]
        public string nameNPC;
        [NonReorderable]
        public DataDialogue[] dataDialogues;
    }
    [System.Serializable]
    public class DataDialogue
    {
        [Header("��ܤ��e")]
        public string Content;
        [Header("��ܭ���")]
        public AudioClip sound;
    }
}