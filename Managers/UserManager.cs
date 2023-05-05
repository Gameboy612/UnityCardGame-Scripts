using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{


    [SerializeField] public DeckManager deckManager;

    // Monster Card Field
    [SerializeField] public HandManager handManager;
    [SerializeField] public MonsterCardFieldManager monsterCardManager;



    public bool summonMonster(
        MonsterCard monsterCard,
        int index
        )
    {
        return monsterCardManager.summonMonster(monsterCard, index);
    }
    
    

    
}
