using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Singleton
{
    public class GameManager : Singleton<GameManager>
    //Managers are really useful for Singleton pattern. (E.g. GameManager, UIManager, EnemyManager)
    {
        public bool isGamePaused = false;
        public Player playerRef;

        // Start is called before the first frame update
        void Start()
        {
            playerRef = FindAnyObjectByType<Player>();
            Debug.Log(playerRef.transform.name);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TogglePause()
        {
            if (isGamePaused)
            {
                isGamePaused = false;
            }
            else
            {
                isGamePaused = true;
            }
        }
    }
}
