using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool isUserTurn = true;
    [SerializeField] public UserManager PlayerUser;
    [SerializeField] public UserManager OpponentUser;

    void Start() {
        PlayerUser.ShuffleCards();
        OpponentUser.ShuffleCards();

        PlayerUser.HandManager.DrawCard(3);
        OpponentUser.HandManager.DrawCard(3);

        PlayerUser.summonMonster(PlayerUser.HandManager.Hand[0] as MonsterCard, 0);
        OpponentUser.summonMonster(OpponentUser.HandManager.Hand[0] as MonsterCard, 0);

    }

}
