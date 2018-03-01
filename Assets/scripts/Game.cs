using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gnogger_Tropple.Classes;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.scripts
{


    public class Game : MonoBehaviour
    {

        public Deck deck;
        public Text deckCount;

        public Transform Board;

        public Player temp = null;

        public Player PlayerOne;
        public Player PlayerTwo;

        public Player CurrentPlayer = null;
        public Player OpposingPlayer = null;

        public Discard discard;
        public Text discardCount;

        public Text hp;
        public Text playCount;
        public Text shield;
        public Text xcount;
        public Text ycount;
        public Text zcount;
        public Text dcount;
        public Text ocount;

        public Text hp2;
        public Text playCount2;
        public Text shield2;
        public Text xcount2;
        public Text ycount2;
        public Text zcount2;
        public Text dcount2;
        public Text ocount2;

        public Text Message;
        private string message;

        public Button endTurn;
        public Button endTurn2;

        private UnityAction listener;

        

        void Start()
        {
            DealHands();
            PlayerOne.IsCurrentPlayer = true;
            PlayerTwo.IsCurrentPlayer = false;
            TurnStart(PlayerOne);
        }

        //public Deck Deck { get; }



        //public bool IsPlayerOnesTurn { get => PlayerOne.IsCurrentPlayer; }
        //public bool IsPlayerTwosTurn { get => PlayerTwo.IsCurrentPlayer; }

        ////public Player CurrentPlayer { get => GetCurrentPlayer(); }
        ////public Player OpposingPlayer { get => GetOpposingPlayer(); }

        //public Player CurrentPlayer { get; set; } = new Player();
        //public Player OpposingPlayer { get; set; } = new Player();

        ////public Pile ThisPile { get => CurrentPlayer. }

        //public Discard Discard { get; }

        void Awake()
        {

            message = "";

            Button btn1 = endTurn.GetComponent<Button>();
            Button btn2 = endTurn2.GetComponent<Button>();
            btn1.onClick.AddListener(TurnEnd);
            btn2.onClick.AddListener(TurnEnd);

        }

        void Update()
        {
            KeepScore();
        }

        //public void OnPlayCard(PointerEventData d)
        //{
        //    GameObject play = d.pointerDrag;
        //    GameObject pile = d.pointerEnter;

        //    Debug.Log(play.name + "is in play");
        //    Debug.Log(pile.name + "is pile card is being played on");

        //    pile.GetComponent<Pile>().AddToPile(play.GetComponent<Card>());

        //    player.PlayCount--;

        //}

        private void KeepScore()
        {
            hp.text = "HP : " + PlayerOne.HealthPoints;
            playCount.text = "Play Count: " + PlayerOne.PlayCount;
            shield.text = "Shield: " + PlayerOne.Shield;
            xcount.text = "x - " + (PlayerOne.PileA.XCount + PlayerOne.PileB.XCount);
            ycount.text = "y - " + (PlayerOne.PileA.YCount + PlayerOne.PileB.YCount);
            zcount.text = "z - " + (PlayerOne.PileA.ZCount + PlayerOne.PileB.ZCount);
            dcount.text = "Δ - " + (PlayerOne.PileA.ΔCount + PlayerOne.PileB.ΔCount);
            ocount.text = "Ω - " + (PlayerOne.PileA.ΩCount + PlayerOne.PileB.ΩCount);
            discardCount.text = discard.CardsInDiscard.Count.ToString();
            deckCount.text = deck.Cards.Count.ToString();

            hp2.text = "HP : " + PlayerTwo.HealthPoints;
            playCount2.text = "Play Count: " + PlayerTwo.PlayCount;
            shield2.text = "Shield: " + PlayerTwo.Shield;
            xcount2.text = "x - " + (PlayerTwo.PileA.XCount + PlayerTwo.PileB.XCount);
            ycount2.text = "y - " + (PlayerTwo.PileA.YCount + PlayerTwo.PileB.YCount);
            zcount2.text = "z - " + (PlayerTwo.PileA.ZCount + PlayerTwo.PileB.ZCount);
            dcount2.text = "Δ - " + (PlayerTwo.PileA.ΔCount + PlayerTwo.PileB.ΔCount);
            ocount2.text = "Ω - " + (PlayerTwo.PileA.ΩCount + PlayerTwo.PileB.ΩCount);

            Message.text = message;

        }

        public void PlayersTurn(Player player)
        {
            TurnStart(player);

            TurnEnd();
        }

        public void TurnStart(Player player)
        {
            Debug.Log("It is " + player.name + "'s turn");

            message = player.name + "'s turn.\n";

            player.PlaysThisTurn = 0;
            SetCurrentPlayer();

            DealDamage();
            DrawOne();
            if (TotalTypeCount(player, "Δ") >= 2)
            {
                DrawOne();
            }
        }

        public void TurnEnd()
        {
            Debug.Log("button clicked");

            GainLife();

            CurrentPlayer.IsCurrentPlayer = !CurrentPlayer.IsCurrentPlayer;
            OpposingPlayer.IsCurrentPlayer = !OpposingPlayer.IsCurrentPlayer;

            SetCurrentPlayer();

            Board.Rotate(180, 180, 0);

            SwitchPlayer();
        }

        public void SwitchPlayer()
        {
            TurnStart(CurrentPlayer);
        }

        public void DealHands()
        {
            deck.Deal(10);

            for (int i = 0; i < 5; i++)
            {
                Instantiate(deck.cardsDealt[0], PlayerOne.handPlacement);
                deck.cardsDealt.Remove(deck.cardsDealt[0]);

                Instantiate(deck.cardsDealt[0], PlayerTwo.handPlacement);
                deck.cardsDealt.Remove(deck.cardsDealt[0]);
            }
        }

        public void PlayCard()
        {
            CurrentPlayer.PlaysThisTurn++;
        }

        public void DrawOne()
        {
            CurrentPlayer.DrawCard(deck.TopCard);
            deck.Cards.Remove(deck.TopCard);
        }

        public void DrawTwo()
        {
            CurrentPlayer.DrawCard(deck.TopCard);
            deck.Cards.Remove(deck.TopCard);
            CurrentPlayer.DrawCard(deck.TopCard);
            deck.Cards.Remove(deck.TopCard);

        }



        //public void SetStartingPlayer()
        //{
        //    Random r = new Random();

        //    int p = r.Next(1, 2);

        //    switch (p)
        //    {
        //        case 1:
        //            PlayerOne.IsCurrentPlayer = true;
        //            break;
        //        case 2:
        //            PlayerTwo.IsCurrentPlayer = true;
        //            break;
        //    }
        //}

        public void SetCurrentPlayer()
        {
            if (PlayerOne.IsCurrentPlayer)
            {
                CurrentPlayer = PlayerOne;
                OpposingPlayer = PlayerTwo;
            }
            else if (PlayerTwo.IsCurrentPlayer)
            {
                CurrentPlayer = PlayerTwo;
                OpposingPlayer = PlayerOne;
            }
        }

        public Player GetCurrentPlayer()
        {
            if (PlayerOne.IsCurrentPlayer)
            {
                return PlayerOne;
            }
            else if (PlayerTwo.IsCurrentPlayer)
            {
                return PlayerTwo;
            }
            else
            {
                return null;
            }
        }

        public Player GetOpposingPlayer()
        {
            if (PlayerOne.IsCurrentPlayer)
            {
                return PlayerTwo;
            }
            else if (PlayerTwo.IsCurrentPlayer)
            {
                return PlayerOne;
            }
            else
            {
                return null;
            }
        }

        public bool GetPlayability(GameObject card)
        {
            bool playable = true;
            string cardType = card.GetComponent<Card>().Type;

            if (cardType == "Z" && CurrentPlayer.TotalCardsInPlay == 0)
            {
                playable = false;
                message = "'" + card.GetComponent<Card>().Type + "' is not a valid play";
            }
            else if (cardType == "Ω" && CurrentPlayer.TotalCardsInPlay < 3)
            {
                playable = false;
                message = "'" + card.GetComponent<Card>().Type + "' is not a valid play";
            }
            else if (cardType == "Δ" && !HasOneOfEveryOtherCard(CurrentPlayer))
            {
                playable = false;
                message = "'" + card.GetComponent<Card>().Type + "' is not a valid play";
            }
            else
            {
                message = "";
            }

            return playable;

        }


        public int TotalTypeCount(Player player, string type)
        {
            return player.PileA.TypeCount(type) + player.PileB.TypeCount(type);
        }

        private bool HasOneOfEveryOtherCard(Player player)
        {
            return TotalTypeCount(player, "X") > 0 
                && TotalTypeCount(player, "Y") > 0 
                && TotalTypeCount(player, "Z") > 0 
                && TotalTypeCount(player, "Ω") > 0;
        }

        //public void ClearPile()
        //{
        //    Discard.AddToDiscard(ThisPile.CardsInPile);
        //    ThisPile.CardsInPile.Clear();
        //}

        //public void ClearPile(Pile pile)
        //{
        //    Discard.AddToDiscard(pile.CardsInPile);
        //    pile.CardsInPile.Clear();
        //}

        ////public Pile GetThisPile(Pile pile)
        ////{
        ////   return CurrentPlayer.
        ////}

        int damage = 0;

        public void DealDamage()
        {
            int shieldPoints = OpposingPlayer.Shield;
            damage = TotalTypeCount(CurrentPlayer, "X");
            damage -= shieldPoints;


            if (damage > 0)
            {
                OpposingPlayer.HealthPoints -= damage;
                message += CurrentPlayer.name + " dealt " + damage + " damage. ";
            }
        }

        int life = 0;

        public void GainLife()
        {
            life = TotalTypeCount(CurrentPlayer, "Y");
            CurrentPlayer.HealthPoints += life / 2;
            
            if (life > 0)
            {
                message += CurrentPlayer.name + " gained " + life + " life.";
            }

        }

        //public void TroppleX(Pile currentPile)
        //{
        //    OpposingPlayer.HealthPoints -= (15 - OpposingPlayer.Shield);
        //    ClearPile(currentPile);
        //}

        //public void TroppleY(Pile pile)
        //{
        //    CurrentPlayer.HealthPoints += 10;
        //    ClearPile(pile);
        //}

        //public void TroppleZ(Pile currentPile, Pile opposingPile)
        //{
        //    ClearPile(opposingPile);
        //    ClearPile(currentPile);
        //}



    }
}
