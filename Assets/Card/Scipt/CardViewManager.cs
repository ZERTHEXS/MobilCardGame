using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardViewManager : MonoBehaviour
{
    public int ID;
    public TextMeshProUGUI cardName;
    public Image illustration;
    public Image rank;
    public TextMeshProUGUI action;
    public List<TextMeshProUGUI> stat;
    public List<Image> statType;
    public List<Image> Heritage;
    public List<Color> colors;
    public List<Sprite> StatTypeSprite;
    private CardSciptableObject data;
    public void Init(CardSciptableObject cardData)
    {
        data = cardData;
        cardName.text = data.cardName;
        illustration.sprite = data.cardIllu;

       
        for (int i = 0; i < stat.Count; i++)
        {
            stat[i].text=data.cardStats[i].value.ToString();   
             switch (data.cardStats[i].type)
            {
                case StatType.Attaque:
                statType[i].sprite = StatTypeSprite[0];
                break;
                case StatType.Defence:
                statType[i].sprite = StatTypeSprite[1];
                break;
                case StatType.Heal:
                statType[i].sprite = StatTypeSprite[2];
                break;
                case StatType.Monney:
                statType[i].sprite = StatTypeSprite[3];
                break;
                case StatType.Tresor:
                statType[i].sprite = StatTypeSprite[4];
                break;
            }     
             switch (data.cardStats[i].heritage)
            {
                case false:
                Heritage[i].gameObject.SetActive(true);
                break;
                case true:
                Heritage[i].gameObject.SetActive(false);
                break;
            }       
        }
       

        switch (data.cardRank)
        {
            case ColorRank.Commun:
            rank.color = colors[0];
            return;
            case ColorRank.Rare:
            rank.color = colors[1];
            return;
            case ColorRank.Epique:
            rank.color = colors[2];
            return;
            case ColorRank.Legendaire:
            rank.color = colors[3];
            return;
            default:
            return;
        }
    }
}
