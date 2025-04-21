using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.ObjectPooling
{
    public class ObjectPoolIdentifier : MonoBehaviour
    {
        public GameObject prefabIdentifier { get; private set; }

        public void Initilize(GameObject prefab)
        {
            prefabIdentifier = prefab;
        }
    }
}
