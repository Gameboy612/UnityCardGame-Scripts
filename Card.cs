using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    public int handIndex = -1;

    private GameManager gm;


    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void OnMouseDown() {
        gm = FindObjectOfType<GameManager>(); 
        if (handIndex == -1) return;
        gm.OnPlayCard(handIndex);
    }

    public virtual bool checkAvailability() {
        return false;
    }

    public virtual void playCard(UserManager userManager) {
        
    }
}
