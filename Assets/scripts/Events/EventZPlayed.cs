using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace Assets.scripts.Events
{
    public class EventZPlayed : MonoBehaviour
    {
        private UnityAction listener;

        void Awake()
        {
            listener = new UnityAction(PlayZ);
        }

        void OnEnable()
        {
            EventManager.StartListening("playZ", listener);
        }

        void OnDisable()
        {
            EventManager.StopListening("playZ", listener);
        }

        public void PlayZ()
        {
            Debug.Log("Z played");
            EventManager.TriggerEvent("removeCard");
        }
    }
}
