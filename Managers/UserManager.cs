using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{


    [SerializeField] public List<Card> Deck = new List<Card>();
    
    // Monster Card Field
    [SerializeField] public HandManager HandManager;
    [SerializeField] public MonsterCardFieldManager MonsterCardManager;


    public void ShuffleCards() {
        int n = Deck.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            Card value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }
    }

    public bool summonMonster(
        MonsterCard monsterCard,
        int index
        )
    {
        return MonsterCardManager.summonMonster(monsterCard, index);
    }
    
    

    
}
