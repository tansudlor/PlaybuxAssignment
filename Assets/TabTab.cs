using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabTab : MonoBehaviour
{
    public GameObject inventoryArea;
    public GameObject tabArea;
    public List<Image> currentImage;
    public Sprite[] originalSprite;
    public Sprite[] tabsSprite;
    
    // Start is called before the first frame update
    private void Start()
    {

        for (int i = 0; i < tabArea.transform.GetChild(0).childCount; i++)
        {
            currentImage.Add(tabArea.transform.GetChild(0).GetChild(i).gameObject.transform.GetComponent<Image>());
        }
        TurnOntabs("hat");
    }
    public void TurnOntabs(string type)
    {
        int aaa = 0;
        switch(type)
        {

            case "all": aaa = 1; break;
            case "hat": aaa = 2; break;
            case "head": aaa = 3; break;
            case "face": aaa = 4; break;
            case "shirt": aaa = 5; break;
            case "pants": aaa = 6; break;
            case "back": aaa = 7; break;
            case "shoes": aaa = 8; break;

        }
        Debug.Log("aaa" + aaa);
        for (int i = 0; i < currentImage.Count; i++)
        {
            
            currentImage[i].GetComponent<Image>().sprite = originalSprite[i];
        }
        
        currentImage[aaa - 1].GetComponent<Image>().sprite = tabsSprite[aaa - 1];
        InventoryManager._inventoryManager.createListOrder(aaa);
    }
}
