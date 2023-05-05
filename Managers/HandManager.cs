using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    
    // Hand Cards
    public List<GameObject> Hand = new List<GameObject>();
    public List<GameObject> Hand_Object = new List<GameObject>();
    
    // Card Locations
    [SerializeField] Transform Hand_Transform;
    // Folder to save the cards
    [SerializeField] GameObject Hand_ParentObject;


    private GameManager gm;
    private UserManager userManager;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        userManager = GetComponentInParent<UserManager>();
    }

    
    public void DrawCard(int count = 1) {
        List<GameObject> Deck = userManager.deckManager.Deck;

        for(int i = 0; i < count; i++) {
            if (Deck.Count == 0) return;
            GameObject card = Deck[Deck.Count - 1];
            Hand.Add(Deck[Deck.Count - 1]);
            Deck.RemoveAt(Deck.Count - 1);

            // Instantiate
            GameObject cardObject = card;
            cardObject.transform.SetParent(Hand_ParentObject.transform, false);
            Hand_Object.Add(cardObject);
            updateCardLocations();
        }
    }


    public float[] getHandCardLocations() {
        int length = Hand.Count;
        float[] output = new float[length];
        for(int i = 0; i < length; i++) {
            // Fix Formula here
            output[i] = i - length / 2.0f;
        }
        return output;
    }

    public void updateCardLocations() {
        float[] loc = getHandCardLocations();

        for(int i = 0; i < Hand.Count; i++) {
            Hand_Object[i].transform.position = Hand_Transform.position + new Vector3(loc[i] * 2, 0, 0);
            Hand_Object[i].transform.rotation = Hand_Transform.rotation;
            Hand_Object[i].transform.localScale = Hand_Transform.localScale;
            
            Hand_Object[i].GetComponent<Card>().handIndex = i;
        }
    }

    public void playCard(int index) {
        if(index < 0 || index > Hand.Count) {
            Debug.LogWarning($"[UserManager] playCard: Out of Range [{index}]");
            return;
        }
        if(Hand[index] == null) {
            Debug.LogWarning($"[UserManager] playCard: index [{index}] is null");
            return;
        }

        GameObject card = Hand[index];
        bool isUsable = card.GetComponent<Card>().checkAvailability();

        if(!isUsable) {
            Debug.LogWarning($"[UserManager] playCard: index [{index}] is not usable under this condition.");
        }

        // Use Card
        card.GetComponent<Card>().playCard(userManager);
        
        // Delete Card
        Hand.RemoveAt(index);
        Hand_Object.RemoveAt(index);
        Debug.Log(Hand.Count);
        updateCardLocations();
        return;

    }
}
