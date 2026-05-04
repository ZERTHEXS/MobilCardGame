using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public abstract void
    Execute(CardContext context);
}
public class CardInstance
{
    public CardSciptableObject data;
    public List<CardStats> modifieStats;
}
public class CardContext
{
    public CardInstance currentCard;

}