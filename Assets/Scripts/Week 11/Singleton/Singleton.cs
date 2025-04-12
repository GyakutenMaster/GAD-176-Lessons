using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // search the scene to see if there is one.
                    instance = FindAnyObjectByType<T>();

                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name + " Singleton");
                        instance = singletonObject.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
