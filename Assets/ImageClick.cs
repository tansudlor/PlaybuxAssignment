using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClick : MonoBehaviour
{

    public Image image;
    public int id;
    // Start is called before the first frame update
    public void SetData(Sprite sprite,int listID)
    {
        image.sprite = sprite;
        id = listID;
    }

    public void ShowData()
    {
        InventoryManager._inventoryManager.LoadSelectData(id);
    }
}
