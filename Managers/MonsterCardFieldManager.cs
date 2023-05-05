using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCardFieldManager : MonoBehaviour
{
    const int MONSTER_CARD_LIMIT = 5;

    [SerializeField] MonsterCard[] MonsterCards;
    public GameObject[] MonsterCards_Object = new GameObject[MONSTER_CARD_LIMIT];

    [SerializeField] Transform[] MonsterCards_Transform;
    [SerializeField] GameObject MonsterCards_ParentObject;
    
    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    // public bool addMonster(
    //     MonsterCard monsterCard,
    //     int index
    //     )
    // {
    //     if(0 < index || index >= MONSTER_CARD_LIMIT) return false;
    //     if(MonsterCards[index] != null) {
    //         Debug.LogWarning($"Card Slot {index} already occupied!");
    //         return false;
    //     };
    //     MonsterCards[index] = monsterCard;
    //     MonsterCards_Object[index] = Instantiate(monsterCard.prefab, new Vector3(0, 0, 0), Quaternion.identity);
    //     MonsterCards_Object[index].transform.parent = MonsterCards_ParentObject.transform;
    //     MonsterCards_Object[index].transform.position = MonsterCards_Transform[index].position;
    //     MonsterCards_Object[index].transform.rotation = MonsterCards_Transform[index].rotation;
    //     MonsterCards_Object[index].transform.localScale = MonsterCards_Transform[index].localScale;
    //     return true;
    // }

    
    public bool summonMonster(
        MonsterCard monsterCard,
        int index
        )
    {
        if(0 < index || index >= MONSTER_CARD_LIMIT) return false;
        if(MonsterCards[index] != null) {
            Debug.LogWarning($"Card Slot {index} already occupied!");
            return false;
        };

        monsterCard.gameObject.transform.SetParent(MonsterCards_ParentObject.transform, false);
        monsterCard.gameObject.transform.position = MonsterCards_Transform[index].position;
        monsterCard.gameObject.transform.rotation = MonsterCards_Transform[index].rotation;
        monsterCard.gameObject.transform.localScale = MonsterCards_Transform[index].localScale;

        MonsterCards[index] = monsterCard;
        MonsterCards_Object[index] = monsterCard.gameObject;
        return true;
    }

}


