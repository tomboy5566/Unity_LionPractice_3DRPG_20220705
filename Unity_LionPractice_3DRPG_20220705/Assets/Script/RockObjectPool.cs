using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace KuanLun
{
    public class RockObjectPool : MonoBehaviour
    {
        [SerializeField, Header("碎片")]
        private GameObject prefabRock;
        [SerializeField, Header("碎片最大數量")]
        private int countMaxRock = 30;

        private int count;

        private ObjectPool<GameObject> poolRock;

        private void Awake()
        {
            poolRock = new ObjectPool<GameObject>(
                CreatePool, GetRock, ReleaseRock, DestroyRock, false, countMaxRock);

        }
        private GameObject CreatePool()
        {
            count++;
            GameObject temp = Instantiate(prefabRock);
            temp.name = prefabRock + " " + count;
            return temp;
        }

        private void GetRock(GameObject rock)
        {
            rock.SetActive(true);
        }

        private void ReleaseRock(GameObject rock)
        {
            rock.SetActive(false);
        }

        private void DestroyRock(GameObject rock)
        {
            Destroy(rock);
        }

        public GameObject GetPoolObject()
        {
            return poolRock.Get();
        }

        public void ReleasePoolObject(GameObject rock)
        {
            poolRock.Release(rock);
        }
    }
}