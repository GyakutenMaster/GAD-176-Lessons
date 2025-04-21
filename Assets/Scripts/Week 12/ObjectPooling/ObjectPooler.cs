using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAE.GAD176.Tutorials.Singleton;

namespace SAE.GAD176.Tutorials.ObjectPooling
{
    public class ObjectPooler : Singleton<ObjectPooler>
    {
        // this is my dictionary.
        private Dictionary<GameObject,List<GameObject>> objectPools = new Dictionary<GameObject, List<GameObject>>();

        // spawn from the pool
        public GameObject SpawnFromPool(GameObject prefab, Vector3 position, Quaternion rotataion)
        {
            if(objectPools.ContainsKey(prefab) != true)
            {
                // not in the dictionary, we should create a new entry.
                CreateNewPoolEntry(prefab);
            }

            // if we get to here, then there's already an entry in our dictionary for this prefab.
            List<GameObject> currentPool = objectPools[prefab];

            Debug.Log(currentPool.Count);

            if(currentPool.Count <= 0)
            {
                // we need to spawn in a new object and add it to our pool
                GameObject newInstance = Instantiate(prefab);
                AddToPool(newInstance, prefab, currentPool);
            }

            // if we get to here, then our pool has numbers or items in it.
            // if that's the case, let's just move our objects to it's new position, roation, etc.
            GameObject currentObjectToSpawn = currentPool[0]; // grab first one out of the pool
            currentPool.RemoveAt(0); // remove the first one from the list.

            // set it's new position and rotation
            currentObjectToSpawn.transform.position = position;
            currentObjectToSpawn.transform.rotation = rotataion;

            currentObjectToSpawn.SetActive(true); // turning the object back on when I bring it back.

            return null;
        }

        // return to the pool
        public void ReturnToPool(GameObject obj)
        {
            ObjectPoolIdentifier poolIdentifier = obj.GetComponent<ObjectPoolIdentifier>();
            if(poolIdentifier != null)
            {
                if(objectPools.ContainsKey(poolIdentifier.prefabIdentifier))
                {
                    objectPools[poolIdentifier.prefabIdentifier].Add(obj);
                    Debug.Log(objectPools[poolIdentifier.prefabIdentifier].Count);
                }
                
                else
                {
                    // removing due to the fact that this is only for objects already in the scene
                    // so it wasn't instantiated so there is no pool.
                    Destroy(obj);
                    // but would create an issue that it'd be separate entires, kinda making it useless.
                    //// this is the scenario, that it has a pool identifier
                    //// but it doesn't have a pool entry yet.
                    //// so we need to create the pool entry, based on the identifiers prefab.
                    //poolIdentifier.Initilize(obj);
                    //CreateNewPoolEntry(obj);
                }
            }
            else
            {
                // removing due to the fact that this is only for objects already in the scene
                // so it wasn't instantiated so there is no pool.
                Destroy(obj);
                //// do something if no identifier and not currently in the pool
                //CreateNewPoolEntry(obj);
                //// so here adding to the newly created pool.
                //// we are passing in the object in this case is the thing already in the scene.
                //// so it's own prefab.
                //AddToPool(obj, obj, objectPools[obj]);
            }

            if(obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }

            if (obj.GetComponent<Rigidbody2D>())
            {
                obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                obj.GetComponent<Rigidbody2D>().angularVelocity = 0;
            }

            obj.SetActive(false); // turning the object off before I add it to the pool so you can't see it.
        }

        public void ReturnToPool(GameObject obj, float time)
        {
            StartCoroutine(ReturnToPoolAfterSeconds(obj, time));
        }

        private IEnumerator ReturnToPoolAfterSeconds(GameObject obj, float time)
        {
            yield return new WaitForSeconds(time);
            ReturnToPool(obj);
        }

        /// <summary>
        /// this adds a new entry to the dictionary.
        /// </summary>
        /// <param name="prefab"></param>
        private void CreateNewPoolEntry(GameObject prefab)
        {
            Debug.Log("Not currently in the Object Pool, creating entry!");
            List<GameObject> newPool = new List<GameObject>();
            
            // access the dictionary and add a new key, and a new value, adding a new entry to the dictionary.
            objectPools.Add(prefab, newPool);
        }

        /// <summary>
        /// This one adds a new pool object to an existing dictionary.
        /// </summary>
        /// <param name="newInstance"></param>
        /// <param name="prefabOriginal"></param>
        /// <param name="pool"></param>
        private void AddToPool(GameObject newInstance, GameObject prefabOriginal, List<GameObject> pool)
        {
            if (!newInstance.GetComponent<ObjectPoolIdentifier>())
            {
                // add the component if it's missing.
                newInstance.AddComponent<ObjectPoolIdentifier>();
            }
            if (newInstance.GetComponent<ObjectPoolIdentifier>())
            {
                newInstance.GetComponent<ObjectPoolIdentifier>().Initilize(prefabOriginal);
            }
            newInstance.SetActive(false);
            pool.Add(newInstance);
        }
    }
}
