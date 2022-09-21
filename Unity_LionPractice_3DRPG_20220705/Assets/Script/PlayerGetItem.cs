using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuanLun
{
    public class PlayerGetItem : MonoBehaviour
    {
        private RockObjectPool rockObjectPool;
        private string propRock = "¥ÛÀY®Ö¤ß¸H¤ù";

        private void Awake()
        {
            rockObjectPool = FindObjectOfType<RockObjectPool>();
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propRock))
            {
                rockObjectPool.ReleasePoolObject(hit.gameObject);
            }
        }
    }
}