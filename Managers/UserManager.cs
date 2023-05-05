using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{


    [SerializeField] List<Card> Deck = new List<Card>();
    
    // Monster Card Field
    [SerializeField] MonsterCardFieldManager MonsterCardField;

    // Hand Cards
    public List<Card> Hand = new List<Card>();
    public List<GameObject> Hand_Object = new List<GameObject>();
    
    // Card Locations
    [SerializeField] Transform Hand_Transform;
    // Folder to save the cards
    [SerializeField] GameObject Hand_ParentObject;

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

    public void DrawCard(int count = 1) {
        for(int i = 0; i < count; i++) {
            if (Deck.Count == 0) return;
            Card card = Deck[Deck.Count - 1];
            Hand.Add(Deck[Deck.Count - 1]);
            Deck.RemoveAt(Deck.Count - 1);

            // Instantiate
            GameObject cardObject = Instantiate(card.prefab, new Vector3(0, 0, 0), Quaternion.identity);
            cardObject.transform.parent = Hand_ParentObject.transform;
            Hand_Object.Add(cardObject);
            updateCardLocations();
        }
    }

    public bool summonMonster(
        MonsterCard monsterCard,
        int index
        )
    {
        return MonsterCardField.summonMonster(monsterCard, index);
    }
    
    public float[] getHandCardLocations() {
        int length = Hand.Count;
        float[] output = new float[length];
        for(int i = 0; i < length; i++) {
            // Fix Formula here
            output[i] = i - length / 2;
        }
        return output;
    }

    public void updateCardLocations() {
        float[] loc = getHandCardLocations();

        for(int i = 0; i < Hand.Count; i++) {
            Hand_Object[i].transform.position = Hand_Transform.position + new Vector3(loc[i] * 2, 0, 0);
            Hand_Object[i].transform.rotation = Hand_Transform.rotation;
            Hand_Object[i].transform.localScale = Hand_Transform.localScale;
        }
    }

    public void useCard(int index) {
        if(index < 0 || index > Hand.Count) {
            Debug.LogWarning($"[UserManager] useCard: Out of Range [{index}]");
            return;
        }
        if(Hand[index] == null) {
            Debug.LogWarning($"[UserManager] useCard: index [{index}] is null");
            return;
        }

        Card card = Hand[index];
        bool isUsable = card.checkAvailability();
    }
}
