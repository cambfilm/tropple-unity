using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.scripts
{
    public class EventPlayCard : MonoBehaviour
    {
        private Player player;

        private string Function;

        private UnityAction someListener;
        private UnityAction newListener;

        void Awake()
        {
            someListener = new UnityAction(PlayFunction);
        }

        void OnEnable()
        {
            EventManager.StartListening("playCard", someListener);
        }

        void OnDisable()
        {
            EventManager.StopListening("playCard", someListener);
        }

        void SomeFunction()
        {
            Debug.Log("Card Played");

        }

        public void PlayFunction()
        {
            Debug.Log("Card Played");
            gameObject.GetComponentInParent<Game>().PlayCard();
        }
    }
}
