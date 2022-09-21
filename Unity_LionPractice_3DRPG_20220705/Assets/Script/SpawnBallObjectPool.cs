using UnityEngine;
using UnityEngine.Pool;

namespace KuanLun
{
    public class SpawnBallObjectPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabBall;

        private ObjectPool<GameObject> poolBall;

        private void Awake()
        {
            poolBall = new ObjectPool<GameObject>(
                CreatePool, GetBall, ReleaseBall, DestroyBall, false, 100);

            InvokeRepeating("Spawn", 0, 0.1f);
        }

        private GameObject CreatePool()
        {
            return Instantiate(prefabBall);
        }

        private void GetBall(GameObject ball)
        {
            ball.SetActive(true);
        }

        private void ReleaseBall(GameObject ball)
        {
            ball.SetActive(false);
        }

        private void DestroyBall(GameObject ball)
        {
            Destroy(ball);
        }

        private void Spawn()
        {
            Vector3 pos;
            pos.x = Random.Range(-15f, 15f);
            pos.y = Random.Range(5f, 7f);
            pos.z = Random.Range(-15f, 15f);
            GameObject tempBall = poolBall.Get();
            tempBall.transform.position = pos;

            tempBall.GetComponent<BallObjectPool>().onHit = BallHitandRelease;
        }

        private void BallHitandRelease(GameObject ball)
        {
            poolBall.Release(ball);
        }
    }
}
