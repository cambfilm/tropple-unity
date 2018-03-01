using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Gnogger_Tropple.Classes
{
    public class Deck : MonoBehaviour
    {
        public GameObject cardX;
        public GameObject cardY;
        public GameObject cardZ;
        public GameObject cardD;
        public GameObject cardO;
        public GameObject deck;
        public Transform deckPlacement;
        public List<GameObject> Cards;
        public List<GameObject> cardsDealt;



        void Awake()
        {
            Cards = new List<GameObject>();

            deck = new GameObject();
            cardsDealt = new List<GameObject>();

            GameObject[] types = { cardX, cardY, cardZ, cardD, cardO }; //types of cards

            foreach (GameObject type in types) //creates 20 cards of each type
            {

                for (int i = 0; i < 20; i++)
                {
                    type.GetComponent<Card>().Type = type.ToString().Substring(4); // adds type to Card.Type
                    Cards.Add(type);
                }
            }

            Shuffle();

        }

        void Start()
        {

        }

        

        public int DeckCount { get { return Cards.Count; } }
        public GameObject TopCard { get { return Cards[0]; } }

        //public Deck()
        //{
        //    //Cards = new List<Card>();

        //    //GameObject[] types = { cardX, cardY, cardZ, cardD, cardO }; //types of cards

        //    //foreach (GameObject type in types) //creates 20 cards of each type
        //    //{
        //    //    for (int i = 0; i < 20; i++)
        //    //    {
        //    //        Instantiate(type);
        //    //        Cards.Add(type);

        //    //    }
        //    //}

        //    //Shuffle();
        //}



        public void Shuffle()
        {
            System.Random r = new System.Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                GameObject temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }

        }

        public void Deal(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (Cards.Count > 0)
                {
                    cardsDealt.Add(Cards[0]);
                    Cards.Remove(cardsDealt[i]);
                }
            }
        }




    }
}
