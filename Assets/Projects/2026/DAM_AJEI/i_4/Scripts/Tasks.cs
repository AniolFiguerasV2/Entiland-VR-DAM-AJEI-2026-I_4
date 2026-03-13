using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public List<Sprite> IceCreamList;
    public List<Sprite> TopingsList;

    public Transform iceCreamPanel;
    public Transform topingPanel;

    public GameObject imagePrefab;

    private List<Sprite> RandomIceCreams = new List<Sprite>();
    private List<Sprite> RandomTopings = new List<Sprite>();

    void Start()
    {
        GenerateRandomSprites();
        DisplaySprites();
    }

    void GenerateRandomSprites()
    {
        int IceCreanQuantity = Random.Range(1, 4);

        for (int i = 0; i < IceCreanQuantity; i++)
        {
            Sprite randomIceCream = IceCreamList[Random.Range(0, IceCreamList.Count)];
            RandomIceCreams.Add(randomIceCream);
        }

        int TopingQuantity = Random.Range(0, 3);

        for (int i = 0; i < TopingQuantity; i++)
        {
            Sprite randomToping = TopingsList[Random.Range(0, TopingsList.Count)];
            RandomTopings.Add(randomToping);
        }
    }
    void DisplaySprites()
    {
        for (int i = 0; i < RandomIceCreams.Count; i++)
        {
            GameObject newImage = Instantiate(imagePrefab, iceCreamPanel);
            Image img = newImage.GetComponent<Image>();
            img.sprite = RandomIceCreams[i];
        }

        for (int i = 0; i < RandomTopings.Count; i++)
        {
            GameObject newImage = Instantiate(imagePrefab, topingPanel);
            Image img = newImage.GetComponent<Image>();
            img.sprite = RandomTopings[i];
        }
    }
}
