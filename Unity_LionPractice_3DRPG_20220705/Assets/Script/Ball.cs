using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class Ball : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("�a�O"))
            {
                Destroy(gameObject);
            }
        }
    }
}