using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class ThirdPersonController : MonoBehaviour
    {
        private Vector3 direction;
        private Transform traCamera;

        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float move = 3.5f;
        [SerializeField, Header("旋轉速度"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("跳躍速度"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController controller;
        #endregion
        #region 事件
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
        #region 功能
        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            transform.rotation = traCamera.rotation;
            direction.z = -v;
            direction.x = -h;
            //print($"垂直方向: {v}");
            controller.Move(direction * move * Time.deltaTime);
        }
        private void Jump()
        {

        }
        #endregion
    }

}