using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Gnogger_Tropple.Classes;
using Assets.scripts;

public class Droppable : MonoBehaviour, IDropHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == transform) 
        {
            d.placeholderParent = d.parentOriginal;
        }
    }

    public void OnDrop(PointerEventData data)
    {
        Draggable d = data.pointerDrag.GetComponent<Draggable>();

        if (d != null && gameObject.GetComponentInParent<Player>().PlayCount > 0 
            && d.gameObject.GetComponentInParent<Pile>() == null 
            && d.gameObject.GetComponent<Card>().IsPlayable)
        {
            DroppedInPile(data);
            d.parentOriginal = transform;
        }

    }


    private void DroppedInPile(PointerEventData data)
    {
        if (gameObject.GetComponent<Pile>() != null)
        {
            Debug.Log(data.pointerDrag.name + "was dropped on " + gameObject.name);
            gameObject.GetComponent<Pile>().AddToPile(data.pointerDrag.GetComponent<Card>());
            data.pointerDrag.transform.SetAsLastSibling();

        }
    }

}
