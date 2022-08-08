using UnityEngine;
using TMPro;
using System.Collections;

namespace KuanLun
{
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("對話系統")]
        private CanvasGroup dialogueSystem;
        [SerializeField, Header("對話者名稱")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("對話內容")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;
        public DataNPC dataNpc;
        [SerializeField, Header("三角形")]
        private GameObject goTriangle;

        [SerializeField, Header("淡入速度")]
        private float intervalFadeIn = 0.1f;
        [SerializeField, Header("打字速度")]
        private float intervalTypeEffect = 0.05f;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            StartCoroutine(StartDialogue());
        }

        public IEnumerator StartDialogue()
        {
            textName.text = dataNpc.nameNPC;
            textContent.text = "";
            yield return StartCoroutine(Fade());

            for (int i = 0; i < dataNpc.dataDialogues.Length; i++)
            {
                yield return StartCoroutine(TypeEffect(i));
                while (!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
            }
            StartCoroutine(Fade(false));
        }

        private IEnumerator Fade(bool fadeIn = true)
        {
            float increase = fadeIn ? 0.1f : -0.1f;
            for (int i = 1; i < 10; i++)
            {
                dialogueSystem.alpha += increase;
                yield return new WaitForSeconds(intervalFadeIn);
            }
        }
        private IEnumerator TypeEffect(int dialogueNumber)
        {
            textContent.text = "";
            aud.PlayOneShot(dataNpc.dataDialogues[dialogueNumber].sound);
            string content = dataNpc.dataDialogues[dialogueNumber].Content;
            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(intervalTypeEffect);
            }
            goTriangle.SetActive(true);
        }
    }

}