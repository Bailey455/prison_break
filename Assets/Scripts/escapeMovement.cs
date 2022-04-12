using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class escapeMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    public TextMeshProUGUI pickUpNum;
    public TextMeshProUGUI enemyHealthText;
    public TextMeshProUGUI healthBar;

    public TextMeshProUGUI pickUpsLeftText;
    public TextMeshProUGUI enemiesLeftText;

    public GameObject player;
    public GameObject enemy;
    public GameObject winScreen;
    public GameObject instructions;
    public GameObject block;

    public GameObject token1;
    public GameObject token2;
    public GameObject token3;
    public GameObject token4;

    //objects for shop method
    public GameObject store;

    public GameObject token1Button;
    public GameObject token2Button;
    public GameObject token3Button;
    public GameObject token4Button;

    bool rDown0 = false;
    bool rDown1 = false;
    bool rDown2 = false;
    bool rDown3 = false;
    bool rDown4 = false;

    int enemyHealth = 100;
    int pickupsLeft = 20;
    public static int numberEnemies = 8;
    public static int pickups = 0;

    public tokenButtons script;

    bool isSprinting = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        setPickupText();

        enemyHealthText.enabled = false;

        instructions.SetActive(true);

    }

    // Update is called multiple times per frame
    void Update()
    {
        checkTokens();
        setPickupText();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 150, out hit, 6))
        {
            if (hit.collider.CompareTag("shop") && Input.GetKey(KeyCode.F))
            {
                store.SetActive(true);
                setPickupText();
            }
            else if (hit.collider.CompareTag("enemy"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    enemyHealthText.enabled = true;
                    setEnemyHealth();
                    enemyHealth = enemyHealth - 10;
                    if (enemyHealth == 0)
                    {
                        enemyHealthText.enabled = false;
                        enemyHealth = 100;
                        numberEnemies -= 1;
                        Destroy(hit.collider.gameObject);
                        healthBar.enabled = false;
                    }
                    setEnemyHealth();
                }
            }
        }

        if (pickups <= 0 && numberEnemies == 0 && tokenButtons.tokens == 4)
        {
            block.SetActive(false);
        }
        else
        {
            block.SetActive(true);
        }
    }

    public void FixedUpdate()
    {

        // fancy movement script
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * Time.deltaTime * movementSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        
        if(isSprinting == true)
        {
            movementSpeed = 15.0f; 
        }
        else
        {
            movementSpeed = 10.0f;
        }
    }

    //pickup method
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            pickups = pickups + 5;
            pickupsLeft -= pickups;
            other.gameObject.SetActive(false); //disables the gameobject it hits
            setPickupText();
        }
        else if (other.gameObject.CompareTag("end"))
        {
            winScreen.SetActive(true);
        }
    }

    //setting pickup count
    public void setPickupText()
    {
        int num = pickups;
        pickUpNum.SetText("Pick ups: " + num.ToString());
    }

    //setting enemyHealth count
    public void setEnemyHealth()
    {
        enemyHealthText.text = "Enemy health: " + enemyHealth.ToString();
    }

    public void checkTokens()
    { 
        //seeing if first token was bought
       if (tokenButtons.tokens == 1)
        {
            if (Input.GetKey(KeyCode.R))
            {
                rDown1 = true;
            }
            else
            {
                rDown1 = false;
            }
        }

        //seeing if second token was bought
        if (tokenButtons.tokens == 2)
        {
            if (Input.GetKey(KeyCode.R))
            {
                rDown2 = true;
            }
            else
            {
                rDown2 = false;
            }
        }

        //seeing if third token was bought
        if (tokenButtons.tokens == 3)
        {
            if(Input.GetKey(KeyCode.R))
            {
                rDown3 = true;
            }
            else
            {
                rDown3 = false;
            }
        }

        //seing if fourth token was bought
        if (tokenButtons.tokens == 4)
        {
            if(Input.GetKey(KeyCode.R))
            {
                rDown4 = true;
            }
            else
            {
                rDown4 = false;
            }
        }

        if (tokenButtons.tokens == 0)
        {
            if(Input.GetKey(KeyCode.R))
            {
                rDown0 = true;
            }
            else
            {
                rDown0 = false;
            }
        }

        //checking if first token should be shown
        if (rDown0 == true)
        {
            enemiesLeftText.enabled = true;
            pickUpsLeftText.enabled = true;
            enemiesLeftText.SetText("Enemies left: " + numberEnemies);
            pickUpsLeftText.SetText("Pickups left: " + pickupsLeft);
        }
        else if (rDown1 == true)
        {
            enemiesLeftText.enabled = true;
            pickUpsLeftText.enabled = true;
            enemiesLeftText.SetText("Enemies left: " + numberEnemies);
            pickUpsLeftText.SetText("Pickups left: " + pickupsLeft);
            token1.SetActive(true);
        }
        else if (rDown2 == true)
        {
            enemiesLeftText.enabled = true;
            pickUpsLeftText.enabled = true;
            enemiesLeftText.SetText("Enemies left: " + numberEnemies);
            pickUpsLeftText.SetText("Pickups left: " + pickupsLeft);
            token1.SetActive(true);
            token2.SetActive(true);
        }
        else if (rDown3 == true)
        {
            enemiesLeftText.enabled = true;
            pickUpsLeftText.enabled = true;
            enemiesLeftText.SetText("Enemies left: " + numberEnemies);
            pickUpsLeftText.SetText("Pickups left: " + pickupsLeft);
            token1.SetActive(true);
            token2.SetActive(true);
            token3.SetActive(true);
        }
        else if (rDown4 == true)
        {
            enemiesLeftText.enabled = true;
            pickUpsLeftText.enabled = true;
            enemiesLeftText.SetText("Enemies left: " + numberEnemies);
            pickUpsLeftText.SetText("Pickups left: " + pickupsLeft);
            token1.SetActive(true);
            token2.SetActive(true);
            token3.SetActive(true);
            token4.SetActive(true);
        }
        else
        {
            enemiesLeftText.enabled = false;
            pickUpsLeftText.enabled = false;
            token1.SetActive(false);
            token2.SetActive(false);
            token3.SetActive(false);
            token4.SetActive(false);
        }
    }
}