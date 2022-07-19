using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class ThirdPersonController : MonoBehaviour
    {
        private Vector3 direction;
        private Transform traCamera;

        #region ���
        [SerializeField, Header("���ʳt��"), Range(0, 50)]
        private float move = 3.5f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("���D�t��"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController controller;
        #endregion
        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            traCamera = GameObject.Find("Main Camera").transform;
        }
        private void Update()
        {
            Move();
        }
        #endregion
        #region �\��
        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            transform.rotation = traCamera.rotation;
            direction.z = -v;
            direction.x = -h;
            //print($"������V: {v}");
            controller.Move(direction * move * Time.deltaTime);
        }
        private void Jump()
        {

        }
        #endregion
    }

}