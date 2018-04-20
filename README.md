# Tropple

A card game where two players duel each other. 
A Player may only play (1) card per turn.
Each player has two Piles to play cards. A pile holds (5) cards. 
There are five different types of cards, each with unique abilities and restrictions. 
If a player controls (5) of one type in a Pile, that is a Tropple. Each type has a different effect when a Tropple occurs.
Players start with (50) Health Points, (0) Shield, and (5) cards.
Players draw (1) card every turn.

## Card Types
### 'X'

Players deal (1) Damage for every (1) 'X' they control to their Opponent at the **beginning** of every turn.

#### 'X' Tropple

Player immediately deals (15) Damage to Opponent. 
Remove all 'X' from the Troppled Pile.

### 'Y'

Players gain (1) HP for every (2) 'Y' they control at the **end** of every turn.

#### 'Y' Tropple

Player immediately gains (10) HP. 
Remove all 'Y' from the Troppled Pile.
### 'Z'

May **not** be played if Player controls no other cards.
When a Player plays a 'Z', they must **remove** one of their cards from play.
If a Player controls a 'Z', they may play (1) extra card per turn for **each** 'Z' they control.

#### 'Z' Tropple
Remove **all** cards from one of the Opponent's Piles. Remove all 'Z' from the Troppled Pile.
### 'Ω'

May only be played if Player controls (3) or more cards.
If Player controls (2) 'Ω' in a single Pile, their **Shield** is equal to (2). If they control (4), it is equal to (5). *This stacks for Pile.*
```
Ex. If there are (2) 'Ω' in one Pile, and (4) in another Pile, that Player has (7) Shield.
```
#### 'Ω' Tropple
Remove (1) card from Opponent's pile. Remove (2) 'Ω' from your pile.
### 'Δ'
May only be played if Player controls (1) of every other type of card.
If Player controls (2) or more 'Δ', they draw an extra card every turn.
Treat 'Δ' as a 'X', 'Y','Z', & 'Ω' when Troppling.
If Player controls a 'Δ', they may only play 'Δ' in a Pile containing a 'Δ'.
#### 'Δ' Tropple
Player chooses a type of card, that is not 'Δ'. They change all cards in their control to that type.
## Shield
Blocks (1) point of damage for every (1) Shield.
## Game End
Game ends when one player runs out of HP.
