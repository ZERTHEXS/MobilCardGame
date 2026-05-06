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

    public CardViewManager view;

    public CardSlot currentSlot;

}
public class CardContext
{
    public CardInstance currentCard;

}