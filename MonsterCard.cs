using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : Card
{
    [SerializeField] public int MaxHealth;
    public int Health;
    [SerializeField] public int Cost;
    [SerializeField] public Ability[] ability;

    private GameManager _gm;
    private int MonsterCardIndex;

    void OnEnable() {
        _gm = FindObjectOfType<GameManager>();
        Health = MaxHealth;
    }

    public void ChangeHealth (int change) {
        Health += change;
    }


    public override bool checkAvailability() {
        return true;
    }

    public override void playCard(UserManager userManager) {
        userManager.summonMonster(this, 0);
    }
}
