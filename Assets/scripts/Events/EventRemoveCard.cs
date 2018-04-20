using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace Assets.scripts.Events
{
    public class EventRemoveCard : MonoBehaviour
    {
        private UnityAction listener;

        void Awake()
        {
            listener = new UnityAction(RemoveCard);
        }

        void OnEnable()
        {
            EventManager.StartListening("removeCard", listener);
        }

        void OnDisable()
        {
            EventManager.StopListening("removeCard", listener);
        }

        public void RemoveCard()
        {
            Debug.Log("Remove card...");
            gameObject.GetComponentInParent<Game>().SetMessage("Choose a card to remove.");
            gameObject.GetComponentInParent<Game>().IsPaused = true;
            
        }
    }
}
