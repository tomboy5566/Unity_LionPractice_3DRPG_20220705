using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC對話資料")]
        private DataNPC dataNPC;
        [SerializeField, Header("NPC攝影機")]
        private GameObject NPCCamera;

        private Animator anTip;
        private string parTipFade = "提示觸發";

        private bool isInTrigger;
        private ThirdPersonController thirdPersonController;
        private DialogueSystem dialogueSystem;

        private Animator aniNPC;
        private string parDialogue = "對話開關";

        private void Awake()
        {
            anTip = GameObject.Find("對話提示底圖").GetComponent<Animator>();
            thirdPersonController = FindObjectOfType<ThirdPersonController>();
            dialogueSystem = FindObjectOfType<DialogueSystem>();
            aniNPC = GetComponent<Animator>();
        }
        private void Update()
        {
            InPlaceAndStartDialogue();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndAnimation(other.name, isInTrigger = true);
        }
        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndAnimation(other.name, isInTrigger = false);
        }
        private void CheckPlayerAndAnimation(string nameIn, bool _isInTrigger)
        {
            isInTrigger = _isInTrigger;
            if (nameIn == "Jammo_LowPoly")
            {
                anTip.SetTrigger(parTipFade);
            }
        }
        private void InPlaceAndStartDialogue()
        {
            if (dialogueSystem.isDialogue) return;
            if (isInTrigger && Input.GetKeyDown(KeyCode.E))
            {
                NPCCamera.SetActive(true);
                anTip.SetTrigger(parTipFade);
                thirdPersonController.enabled = false;
                try
                {
                    aniNPC.SetBool(parDialogue, true);
                }
                catch (System.Exception)
                {
                    print("<color=#993311>缺少元件：NPC沒有Animator</color>");
                }

                StartCoroutine(dialogueSystem.StartDialogue(dataNPC, ResetCameraAndCancelDialogue));
            }
        }
        private void ResetCameraAndCancelDialogue()
        {
            NPCCamera.SetActive(false);
            thirdPersonController.enabled = true;
            anTip.SetTrigger(parTipFade);
            try
            {
                aniNPC.SetBool(parDialogue, false);
            }
            catch (System.Exception)
            {
                print("<color=#993311>缺少元件：NPC沒有Animator</color>");
            }
            
        }
    }
}