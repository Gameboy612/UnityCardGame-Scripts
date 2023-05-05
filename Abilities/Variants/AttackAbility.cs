using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : Ability
{
    public void useAbility(
        int damage,
        MonsterCard source,
        MonsterCard target
    ) {
        Debug.Log("AttackAbility ran");
        target.ChangeHealth(-1 * damage);
    }
}
