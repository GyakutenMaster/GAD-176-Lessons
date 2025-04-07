using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAE.GAD176.Tutorials.Events
{
    public class Events : MonoBehaviour
    {

        public UnityEvent OnFireButtonPressed = new UnityEvent();


        private void OnEnable()
        {
            OnFireButtonPressed.AddListener(PrintMyName);
            GameEvents.OnGameStartEvent += OnFireButtonPressed.Invoke; // I'm calling the Invoke action. However, I'm only going to do it when this GameEvent gets invoked.
        }

        private void OnDisable() // Always make sure to unsubscribe, or the action will repeat forever..
        {
            OnFireButtonPressed.RemoveListener(PrintMyName);
            GameEvents.OnGameStartEvent -= OnFireButtonPressed.Invoke;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                // Confirming if the event has at least 1 subscriber.
                //if(GameEvents.OnGameStartEvent != null)
                //{
                //    GameEvents.OnGameStartEvent.Invoke();
                //}

                GameEvents.OnGameStartEvent?.Invoke(); // Shortcut of the above.
            }
        }

        private void PrintMyName()
        {
            Debug.Log("Ben");
        }
    }
}
