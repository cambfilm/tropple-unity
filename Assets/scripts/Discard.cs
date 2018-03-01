using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class Discard : MonoBehaviour
    {
        public List<Card> CardsInDiscard { get; set; }
        public Transform deckPlacement;

        void Awake()
        {
            CardsInDiscard = new List<Card>();
        }


        public int DiscardCount { get { return CardsInDiscard.Count; } }



        public List<Card> Reshuffle()
        {
            List<Card> reshuffle = CardsInDiscard;
            CardsInDiscard.Clear();
            return reshuffle;
        }

        public void AddToDiscard(List<Card> cards)
        {
            CardsInDiscard.AddRange(cards);
        }

        public void AddToDiscard(Card card)
        {
            Instantiate(card.gameObject, transform);
            Destroy(card.gameObject);
            CardsInDiscard.Add(card);
        }
    }
}

