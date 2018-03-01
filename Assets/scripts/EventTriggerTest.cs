using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace Assets.scripts
{
    public class EventTriggerTest : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown("q"))
            {
                EventManager.TriggerEvent("test");
            }
        }
    }
}