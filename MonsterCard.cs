using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : Card
{
    [SerializeField] public int MaxHealth;
    public int Health;
    [SerializeField] public int Cost;
    [SerializeField] public Ability[] ability;


    private GameManager gm;
    private int MonsterCardIndex;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        Health = MaxHealth;
    }

    public void ChangeHealth (int change) {
        Health += change;
    }

    private void OnMouseDown() {
        if(gm.isUserTurn) {
            // Implement this later, it should take user input then choose first ability to perform.
            // Also, make a new ability object for each card.

        }
    }

    public bool checkAvailability() {
        return false;
    }
}
