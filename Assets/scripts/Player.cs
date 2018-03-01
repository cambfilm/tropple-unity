using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.scripts;


namespace Gnogger_Tropple.Classes
{
    public class Player : MonoBehaviour
    {

        public Pile PileA;
        public Pile PileB;
        public Transform pileAPosition;
        public Transform pileBPosition;
        public Deck deck;
        public Transform handPlacement;
        public GameObject hand;
        public int PlaysThisTurn = 0;

        

        void Awake()
        {
            HealthPoints = 50;
            CardsInHand = new List<GameObject>();
        }

        void Update()
        {

        }

        void Start()
        {
            

        }

        public List<GameObject> CardsInHand;

        public int PlayCount { get { return GetPlayCount(); } } 
        public int HealthPoints { get; set; }
        public int Shield { get { return GetShield(); } }
        public int TotalCardsInPlay { get { return PileA.CardsInPile.Count + PileB.CardsInPile.Count; } }


        public int PlayerNumber { get; set; }

        public bool IsCurrentPlayer { get; set; }

        public void DrawCard(List<GameObject> cards)
        {
            CardsInHand.AddRange(cards);
        }

        public void DrawCard(GameObject card)
        {
            Instantiate(card, handPlacement);
        }

        private int GetPlayCount()
        {
            int playCount = 0;

            if (IsCurrentPlayer)
            {
                playCount += 1 + PileA.ZCount + PileB.ZCount - PlaysThisTurn;
            }

            return playCount;
        }

        //public Player(int playerNumber)
        //{
        //    CardsInHand = new List<Card>();
        //    PlayCount = 0;
        //    HealthPoints = 100;
        //    PileA = new Pile(1);
        //    PileB = new Pile(2);
        //    PlayerNumber = playerNumber;
        //}

        //public Player()
        //{
        //    CardsInHand = new List<Card>();
        //    PlayCount = 0;
        //    HealthPoints = 100;
        //    PileA = new Pile(1);
        //    PileB = new Pile(2);
        //}

        public int GetShield()
        {
            int shield = 0;

            if (PileA.ΩCount >= 2)
            {
                shield += 2;
            }
            else if (PileA.ΩCount >= 4)
            {
                shield += 5;
            }

            if (PileB.ΩCount >= 2)
            {
                shield += 2;
            }
            else if (PileB.ΩCount >= 4)
            {
                shield += 5;
            }

            return shield;
        }


    }
}
