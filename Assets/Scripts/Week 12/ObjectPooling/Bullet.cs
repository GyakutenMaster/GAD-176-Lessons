using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.ObjectPooling
{
    public class Bullet : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ObjectPooler.Instance.ReturnToPool(gameObject,2);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
