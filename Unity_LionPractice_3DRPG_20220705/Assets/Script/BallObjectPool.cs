using Unity.VisualScripting;
using UnityEngine;

namespace KuanLun
{
    public class BallObjectPool : MonoBehaviour
    {
        public delegate void delegateHit(GameObject ball);
        public delegateHit onHit;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("¦aªO"))
            {
                onHit(gameObject);
            }
        }
    }

}