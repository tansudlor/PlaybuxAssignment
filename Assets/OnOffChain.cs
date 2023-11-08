using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffChain : MonoBehaviour
{
    public GameObject onChain;
    public GameObject offChain;
    // Start is called before the first frame update
    bool click = true;

    // Update is called once per frame
    public void SetToggle()
    {
        click = !click;
        onChain.SetActive(click);
        offChain.SetActive(!click);
    }
}
