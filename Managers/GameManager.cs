using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    START,
    PLAYER_TURN,
    OPPONENT_TURN,
    WIN,
    LOSE
}


public class GameManager : MonoBehaviour
{
    [SerializeField] public UserManager playerUser;
    [SerializeField] public UserManager opponentUser;

    public UserManager currentUser;
    public GameState gameState;



    void Start() {
        gameState = GameState.START;
        
        currentUser = playerUser;

        StartCoroutine(SetupGame());

        //playerUser.handManager.playCard(1);
        //opponentUser.handManager.playCard(1);

    }

    IEnumerator SetupGame()
    {
        // 1. Shuffle Cards
        playerUser.deckManager.ShuffleCards();
        opponentUser.deckManager.ShuffleCards();

        // 2. Place Covered Character Card
        
        // 3. Toss Coin

        // 4. Set Crystal Count

        // 5. Draw Card
        playerUser.handManager.DrawCard(5);
        opponentUser.handManager.DrawCard(5);

        // 6. Show Character Card

        yield return new WaitForSeconds(2f);

        gameState = GameState.PLAYER_TURN;
        //PlayerTurn();
    }

    IEnumerator PlayCard(int cardIndex)
    {
        currentUser.handManager.playCard(cardIndex);

        yield return new WaitForSeconds(2f);

        // .......
    }

    public void OnPlayCard(int cardIndex)
    {
        if (gameState != GameState.PLAYER_TURN && gameState != GameState.OPPONENT_TURN) return;

        StartCoroutine(PlayCard(cardIndex));
    }
}
