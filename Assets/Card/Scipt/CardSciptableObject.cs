using UnityEngine;
using System.Collections.Generic;

using UnityEngine.UI;
[CreateAssetMenu(menuName ="Card/CardData")]
public class CardSciptableObject : ScriptableObject
{
   [Header("Info")]
   public int ID;
   public string cardName;
   public Sprite cardIllu;
   public ColorRank cardRank;
   [Header("Stats")]
   public List<CardStats> cardStats;
   [Header("Effect")]
   public List<CardEffect> cardEffect;
}

public enum ColorRank
{
    Commun,
    Rare,
    Epique,
    Legendaire
}
public enum StatType
{
    Attaque,
    Defence,
    Heal,
    Tresor,
    Monney
}
[System.Serializable]
public class CardStats
{
    public StatType type;
    public int value;
    public bool heritage;
}