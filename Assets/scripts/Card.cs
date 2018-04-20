using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Assets.scripts;

public class Card : MonoBehaviour
{

    public virtual string Type { get { return SetType(); } set { } } //

    public bool IsInPile { get; set; } //tells if card is in play

    public bool IsFaceUp { get; set; }

    public bool IsPlayable { get { return gameObject.GetComponentInParent<Game>().GetPlayability(gameObject) && !gameObject.GetComponentInParent<Game>().IsPaused; } }

    public Card() { }

    public Card(string type)
    {
        Type = type;
    }

    public void OnPlayCard()
    { 
        
    }

    private string SetType()
    {
        string type = "";

        type = gameObject.name.Substring(5, 1);

        return type;
    }


}

