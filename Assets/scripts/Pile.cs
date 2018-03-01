using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.scripts;



namespace Gnogger_Tropple.Classes
{
    public class Pile : MonoBehaviour
    {

        Dictionary<string, int> typeCount = new Dictionary<string, int>
        {
            {"X", 0 },
            {"Y", 0 },
            {"Z", 0 },
            {"Ω", 0 },
            {"Δ", 0 }
        };

        public GameObject Discard;
        public Transform DiscardPlacement;

        void Update()
        {
            SetTypeCount();
        }

        void Start()
        {
            CardsInPile = new List<Card>();
        }

        public List<Card> CardsInPile { get; set; }

        public int TypeCount(string type)
        {
            int count = 0;

            switch (type)
            {
                case "X":
                    count = XCount;
                    break;
                case "Y":
                    count = YCount;
                    break;
                case "Z":
                    count = ZCount;
                    break;
                case "Ω":
                    count = ΩCount;
                    break;
                case "Δ":
                    count = ΔCount;
                    break;
            }

            return count;
        }

        public int ΔCount { get { return typeCount["Δ"]; } }
        public int XCount { get { return typeCount["X"]; } }
        public int YCount { get { return typeCount["Y"]; } }
        public int ZCount { get { return typeCount["Z"]; } }
        public int ΩCount { get { return typeCount["Ω"]; } }

        private bool HasTropD { get { return ΔCount == 5; } }
        private bool HasTropX { get { return XCount + ΔCount == 5; } }
        private bool HasTropY { get { return YCount + ΔCount == 5; } }
        private bool HasTropZ { get { return ZCount + ΔCount == 5; } }
        private bool HasTropO { get { return ΩCount + ΔCount == 5; } } 
                                                             
        public int PileCount { get { return CardsInPile.Count; } }

        public int Number { get; set; }

        public bool PileFull { get { return PileCount == 5; } }

        public void OnDroppedInPile(PointerEventData data)
        {
            

        }

        public void AddToPile(Card card)
        {
            EventManager.TriggerEvent("playCard");
            card.IsInPile = true;

            if (PileFull)
            {
                Discard.GetComponent<Discard>().AddToDiscard(Bump(card));
            }
            else
            {
                CardsInPile.Add(card);
            }

        }

        public Card Bump(Card card)
        {
            Card discard = RemoveFromPile();
            CardsInPile.Add(card);
            return discard;
        }

        public Card RemoveFromPile() //removes one card from pile A or B, it goes to the Discard pile
        {
            Card discard = CardsInPile[0];

            CardsInPile.RemoveAt(0); // remove first Card in Pile
                         
            return discard;
        }

        public Card RemoveFromPile(int position)
        {
            Card discard = CardsInPile[position - 1];

            CardsInPile.RemoveAt(position - 1);

            return discard;
        }

        string[] types = { "X", "Y", "Z", "Ω", "Δ" };

        private void SetTypeCount()
        {
            for (int i = 0; i < types.Length; i++)
            {
                int count = 0;

                foreach (Card card in CardsInPile)
                {
                    if (card.Type == types[i])
                    {
                        count++;
                    }
                }

                typeCount[types[i]] = count;
            }
        }

        public void Tropple(string type)
        {

        }


    }
}


