using UnityEngine;

namespace KuanLun
{
    [CreateAssetMenu(menuName = "KuanLun/Data NPC", fileName = "Data NPC", order = 2)]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC 名稱")]
        public string nameNPC;
        [NonReorderable]
        public DataDialogue[] dataDialogues;
    }
    [System.Serializable]
    public class DataDialogue
    {
        [Header("對話內容")]
        public string Content;
        [Header("對話音效")]
        public AudioClip sound;
    }
}