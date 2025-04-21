using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.ObjectPooling
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnPoint;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
                if(clone.GetComponent<Rigidbody>())
                {
                    clone.GetComponent<Rigidbody>().velocity = spawnPoint.forward * 100;
                    Destroy(clone, 2);
                }
            }
        }
    }
}
