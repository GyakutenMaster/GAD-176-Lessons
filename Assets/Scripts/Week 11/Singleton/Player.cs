using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Singleton
{
    public class Player : MonoBehaviour
    {
        // public static int health = 100; // Because this is static, each one of thse players with script will share the same value of this variable. If one take damage, they all take damage.
        // This will be useful in E.g. a game with 4 players but they have a group health pool.

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.TogglePause();
            }
        }
    }
}
