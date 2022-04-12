using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class enemyScript : MonoBehaviour
{
    float health = 100;
    public TextMeshProUGUI healthBar;
    public GameObject loseScreen;


    //Start is called before the first frame update
    void Start()
    {
        SetHealthText();
    }

    void Update()
    {
        //enemy attacking 10 health points per second
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.right) * 150, out hit, 6))
        {
            if (hit.collider.CompareTag("Player"))
            {
                healthBar.enabled = true;
                if (health > 0)
                {
                    health -= 10 * Time.deltaTime;
                    //Debug.Log(health);
                    SetHealthText();
                }
                else
                {
                    loseScreen.SetActive(true);
                    SetHealthText();
                }
            }
        }
    }

    private void SetHealthText()
    {
        int healthDisplay = (int)health;
        healthBar.text = "Health: " + healthDisplay.ToString();
    }
}
