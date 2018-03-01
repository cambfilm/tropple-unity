using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Gnogger_Tropple.Classes;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public Transform parentOriginal = null;
    public Transform placeholderParent = null;

    public GameObject placeholder;

    public void OnBeginDrag(PointerEventData eventD)
    {
        if (gameObject.GetComponent<Card>().IsInPile == false)
        {
            placeholder = new GameObject();
            placeholder.transform.SetParent(transform.parent);
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

            parentOriginal = this.transform.parent;
            placeholderParent = parentOriginal;
            transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventD)
    {
        if (gameObject.GetComponent<Card>().IsInPile == false)
        {
            transform.position = eventD.position;

            int newSiblingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if (placeholderParent.transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }
                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }
    }

    public void OnEndDrag(PointerEventData eventD)
    { 
        transform.SetParent(parentOriginal);
        //transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);


    }

}
