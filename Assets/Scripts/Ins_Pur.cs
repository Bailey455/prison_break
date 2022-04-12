using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins_Pur : MonoBehaviour
{
    public GameObject instructions; 
    public GameObject purpose;
    public GameObject block;
    public GameObject shop;

    public void moveToGame()
    {
        purpose.SetActive(false);
    }

    public void moveToPurpose()
    {
        instructions.SetActive(false);
        purpose.SetActive(true);
    }

    public void moveBack()
    {
        block.SetActive(false);
    }

    public void exitShop()
    {
        shop.SetActive(false);
    }
}

