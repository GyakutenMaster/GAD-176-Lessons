using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.ObjectPooling
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject collectable;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject clone = ObjectPooler.Instance.SpawnFromPool(collectable, Vector3.zero, Quaternion.identity);
                ObjectPooler.Instance.ReturnToPool(clone, 2);
            }
            Invoke("SpawnMoreCoins", 5);
        }

        void SpawnMoreCoins()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject clone = ObjectPooler.Instance.SpawnFromPool(collectable, Vector3.zero, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

                GameObject clone = ObjectPooler.Instance.SpawnFromPool(bulletPrefab, spawnPoint.position, Quaternion.identity);

                if(clone.GetComponent<Rigidbody>())
                {
                    clone.GetComponent<Rigidbody>().velocity = spawnPoint.forward * 100;
                    ObjectPooler.Instance.ReturnToPool(clone, 2);
                }
            }
        }
    }
}
