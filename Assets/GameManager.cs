using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Canvas canvas;
    public CardSciptableObject cardSciptableObject;
    void Start()
    {
        GameObject cardGO = Instantiate(cardPrefab);
        cardGO.transform.SetParent(canvas.transform);

        CardViewManager view = cardGO.GetComponent<CardViewManager>();
        view.Init(cardSciptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
