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
    [SerializeField] private int DammageDeal;
    [SerializeField] private int ArmorDeal;
    [SerializeField] private int HealDeal;
    [SerializeField] private int GoldDeal;
    [SerializeField] private int TresorDeal;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnCardInSlot(currentSlot);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayCard(currentSlot,b1Slot);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayCard(currentSlot,a1Slot);
        }
    }

    public CardInstance CreateCard(CardSciptableObject data)
    {
        GameObject cardGO = Instantiate(cardPrefab, cardParent);
        CardViewManager view = cardGO.GetComponent<CardViewManager>();
        view.Init(data);
        CardInstance instance = new CardInstance();

        instance.data = data;
        instance.view = view;

        return instance;
    }
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
    public void PlayCard(CardSlot playedSlot, CardSlot MoveSlot)
    {
        
        DammageDeal=0;
        ArmorDeal=0;
        HealDeal=0;
        GoldDeal=0;
        TresorDeal=0;

        for (int i = 0; i < 2; i++)
        {
            switch ( playedSlot.currentCard.data.cardStats[i].type)
            {
                case StatType.Attaque:
                DammageDeal += playedSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Defence:
                ArmorDeal += playedSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Heal:
                HealDeal += playedSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Monney:
                GoldDeal += playedSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Tresor:
                TresorDeal += playedSlot.currentCard.data.cardStats[i].value;
                break;
            }  
            if (playedSlot.currentCard.data.cardStats[i].heritage == true && MoveSlot.currentCard != null)
            {
                 switch ( MoveSlot.currentCard.data.cardStats[i].type)
            {
                case StatType.Attaque:
                DammageDeal += MoveSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Defence:
                ArmorDeal += MoveSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Heal:
                HealDeal += MoveSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Monney:
                GoldDeal += MoveSlot.currentCard.data.cardStats[i].value;
                break;
                case StatType.Tresor:
                TresorDeal += MoveSlot.currentCard.data.cardStats[i].value;
                break;
            } 
            }
        }
        Debug.Log($"DamageDeal : {DammageDeal} ArmorDeal : {ArmorDeal} HealDeal : {HealDeal} GoldDeal : {GoldDeal} TresorDeal : {TresorDeal}");
        
        if (playedSlot.currentCard == null)
        {
            Debug.Log("No card in slot");
            return;
        }
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
        MoveSlot.MoveCardToSlot(playedSlot.currentCard);
        playedSlot.currentCard = null;
        SpawnCardInSlot(playedSlot);
    }
}