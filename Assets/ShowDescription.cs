using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static InventoryManager;

public class ShowDescription : MonoBehaviour
{
    public static ShowDescription _showdescription;
    public Image image;
    public Text descriptionTxt;
    public Text ralityTxt;
    public Text collectionTxt;
    public Text nameTxt;
    public GameObject InputArea;
    public List<GameObject> inputAreaChild;
    public List<Sprite> unequieImage;
    // Start is called before the first frame update
    private void Awake()
    {
        _showdescription = this;
    }
    private void Start()
    {
        for (int i = 0; i < InputArea.transform.childCount; i++)
        {
            inputAreaChild.Add(InputArea.transform.GetChild(i).transform.gameObject);
        }
    }
    public void ShowOnUI(string name, string rare, string description, string collection, string imageSting, string data)
    {
        descriptionTxt.text = "Description :";
        nameTxt.text = name;
        ralityTxt.text = rare;
        collectionTxt.text = collection;
        descriptionTxt.text = descriptionTxt.text + " " + description;
        image.sprite = Resources.Load<Sprite>(imageSting);
        SetImageInput(imageSting, data);
    }

    public void SetImageInput(string imageSting, string data)
    {
        print(data);
        for (int i = 0; i < inputAreaChild.Count; i++)
        {
            if (data == inputAreaChild[i].name)
            {
                inputAreaChild[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(imageSting);
            }
        }
    }

    public void UnequieItem(GameObject gameObject)
    {
        var name = gameObject.name;
        for (int i = 0; i < inputAreaChild.Count; i++)
        {
            if (name == inputAreaChild[i].name)
            {
                inputAreaChild[i].GetComponent<Image>().sprite = unequieImage[i];
            }
        }
    }
}
