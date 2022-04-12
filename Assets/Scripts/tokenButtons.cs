using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tokenButtons : MonoBehaviour
{
    public static int tokens = 0;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public static GameObject token1;
    public static GameObject token2;
    public static GameObject token3;
    public static GameObject token4;

    public TextMeshProUGUI pickupText;

    public void disappearFirst()
    {  
        if (escapeMovement.pickups % 5 == 0 && escapeMovement.pickups > 0)
        {
            button1.SetActive(false);
            tokens = 1;
            minusPickups();

        }
    }

    public void disappearSecond()
    {
        if (escapeMovement.pickups % 5 == 0 && escapeMovement.pickups > 0)
        {
            button2.SetActive(false);
            tokens = 2;
            minusPickups();
        }
    }

    public void disappearThird()
    {
        if (escapeMovement.pickups % 5 == 0 && escapeMovement.pickups > 0)
        { 
            button3.SetActive(false);
            tokens = 3;
            minusPickups();
        }
    }

    public void disappearFourth()
    {
        if (escapeMovement.pickups % 5 == 0 && escapeMovement.pickups > 0)
        {
            button4.SetActive(false);
            tokens = 4;
            minusPickups();
        }
    }

    public void minusPickups()
    {
        escapeMovement.pickups -= 5;
    }
}
