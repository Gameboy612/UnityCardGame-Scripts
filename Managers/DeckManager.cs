using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] public List<Card> Deck_Reference = new List<Card>();
    public List<GameObject> Deck = new List<GameObject>();

    [SerializeField] GameObject Deck_Parent; 

    public void Start() {
        int n = Deck_Reference.Count;
        for(int i = 0; i < n; i++) {
            GameObject card = Instantiate(Deck_Reference[i].prefab, new Vector3(0, 0, 0), Quaternion.identity);
            card.transform.SetParent(Deck_Parent.transform, false);

            Deck.Add(card);
        }
    } 

    public void ShuffleCards() {
        int n = Deck.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            GameObject value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }
    }
}
