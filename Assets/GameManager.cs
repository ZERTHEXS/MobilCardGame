using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject cardPrefab;

    [Header("Parents")]
    [SerializeField] private Transform cardParent;

    [Header("Database")]
    [SerializeField] private List<CardSciptableObject> allCards;

    [Header("Slots")]
    [SerializeField] private CardSlot currentSlot;
    [SerializeField] private CardSlot a1Slot;
    [SerializeField] private CardSlot a2Slot;
    [SerializeField] private CardSlot b1Slot;
    [SerializeField] private CardSlot b2Slot;
    [SerializeField] private CardSlot discardSlot;

    private void Update()
    {
        // TEST : Spawn une carte dans current
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnCardInSlot(currentSlot);
        }

        // TEST : Spawn une carte dans A2
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayCard(currentSlot,b1Slot);
        }

        // TEST : Joue la carte de A1
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayCard(currentSlot,a1Slot);
        }
    }

    // =========================
    // CREATE CARD
    // =========================

    public CardInstance CreateCard(CardSciptableObject data)
    {
        // Spawn prefab
        GameObject cardGO = Instantiate(cardPrefab, cardParent);

        // Get view
        CardViewManager view = cardGO.GetComponent<CardViewManager>();

        // Init UI
        view.Init(data);

        // Create runtime instance
        CardInstance instance = new CardInstance();

        instance.data = data;
        instance.view = view;

        return instance;
    }

    // =========================
    // SPAWN RANDOM CARD
    // =========================

    public void SpawnCardInSlot(CardSlot slot)
    {
        if (slot.currentCard != null)
        {
            Debug.Log("Slot already occupied");
            return;
        }

        int randomIndex = Random.Range(0, allCards.Count);

        CardSciptableObject randomCard = allCards[randomIndex];

        CardInstance instance = CreateCard(randomCard);

        slot.MoveCardToSlot(instance);
    }

    // =========================
    // PLAY CARD
    // =========================

    public void PlayCard(CardSlot playedSlot, CardSlot MoveSlot)
    {
        if (playedSlot.currentCard == null)
        {
            Debug.Log("No card in slot");
            return;
        }

        // Ancienne current -> discard
        if (MoveSlot.currentCard != null && MoveSlot==a1Slot)
        { 
            if (a2Slot.currentCard != null)
        {
            discardSlot.MoveCardToSlot(a2Slot.currentCard);
        }
            a2Slot.MoveCardToSlot(MoveSlot.currentCard);
        }
         if (MoveSlot.currentCard != null && MoveSlot==b1Slot)
        {
              if (b2Slot.currentCard != null)
        {
            discardSlot.MoveCardToSlot(b2Slot.currentCard);
        }
            b2Slot.MoveCardToSlot(MoveSlot.currentCard);
        }

        // Nouvelle current
        MoveSlot.MoveCardToSlot(playedSlot.currentCard);

        // Vide le slot joué
        playedSlot.currentCard = null;

        // Refill automatiquement
        SpawnCardInSlot(playedSlot);
    }
}