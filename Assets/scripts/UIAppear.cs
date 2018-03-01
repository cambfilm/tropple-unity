using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;



namespace Assets.scripts
{
    public class UIAppear : MonoBehaviour
    {
        [SerializeField] private Text message;
        public static bool DamgeDealt;
        public static bool LifeGained;
        public static bool IllegalPlay;

        float displayTime = 3;


    }

}
