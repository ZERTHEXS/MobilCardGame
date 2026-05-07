using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public SlotType slotType;

    public Transform visualPoint;

    public CardInstance currentCard;

    public void MoveCardToSlot(CardInstance card)
    {
        currentCard = card;

        card.currentSlot = this;

        card.view.transform.position = visualPoint.position;
        if (card.currentSlot.slotType == SlotType.A1 || card.currentSlot.slotType == SlotType.B1)
        {
            card.view.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }
    }


}public enum SlotType
{
    Current,
    A1,
    A2,
    B1,
    B2,
    Discard
}