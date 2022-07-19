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
        private string parRun = "走跑參數";
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
            Jump();
        }
        #endregion
        #region 功能
        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            transform.rotation = traCamera.rotation;
            transform.eulerAngles = new Vector3(0, traCamera.eulerAngles.y, 0);
            direction.z = v;
            direction.x = h;
            direction = transform.TransformDirection(direction);
            //print($"垂直方向: {v}");
            controller.Move(direction * move * Time.deltaTime);
            float vAxis = Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");
            if (Mathf.Abs(vAxis) > 0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(vAxis));
            }
            else if (Mathf.Abs(hAxis) > 0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(hAxis));
            }
            else
            {
                ani.SetFloat(parRun, 0);
            }
        }
        private void Jump()
        {
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
            }
            direction.y += Physics.gravity.y / 1.5f * Time.deltaTime;
        }
        #endregion
    }

}