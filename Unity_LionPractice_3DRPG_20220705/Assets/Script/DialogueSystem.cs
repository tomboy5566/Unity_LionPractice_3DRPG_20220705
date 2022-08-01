using UnityEngine;
using TMPro;
using System.Collections;

namespace KuanLun
{
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("��ܨt��")]
        private CanvasGroup dialogueSystem;
        [SerializeField, Header("��ܪ̦W��")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;
        public DataNPC dataNpc;
        [SerializeField, Header("�T����")]
        private GameObject goTriangle;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(FadeIn());

            textName.text = dataNpc.nameNPC;
            textContent.text = "";
        }

        private IEnumerator FadeIn()
        {
            for (int i = 1; i < 10; i++)
            {
                dialogueSystem.alpha += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            StartCoroutine(TypeEffect());
        }
        private IEnumerator TypeEffect()
        {
            aud.PlayOneShot(dataNpc.dataDialogues[0].sound);
            string content = dataNpc.dataDialogues[0].Content;
            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(0.05f);
            }
            goTriangle.SetActive(true);
        }
    }

}