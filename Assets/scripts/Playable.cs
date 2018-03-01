using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using Gnogger_Tropple.Classes;

namespace Assets.scripts
{
    public class Playable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {

        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrop(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            BroadcastMessage("PlayCard", eventData.pointerDrag.GetComponent<Card>());
        }


    }
}
