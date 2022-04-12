using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class surviveMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float jumpSpeed = 20.0f;

    bool hitSomething = false;

    public GameObject enemy;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI yourHealthText;

    Collider other;

    int enemyHealth;
    int hits;
    int yourHealth;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hits = 0;
        enemyHealth = 100;
        yourHealth = 100;

        SetHealthText();
        SetEnemyText();

    }

    // Update is called once per frame
    void Update()
    {
        //raycast and checking if you hit the enemy
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right) * 250, out hit, 6))
        //{
        //    hitSomething = true;
        //}

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 150, out hit, 6))
        {
            Debug.Log("Hit something");
            hitSomething = true;
            Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.forward) * 150, Color.green, 6);
        }
        else
        {
            Debug.Log("Nothing hit");
            Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.forward) * 150, Color.blue, 6);
        }

        //Movement Script
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.TransformDirection(movement) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.TransformDirection(movement) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(movement) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.TransformDirection(movement) * Time.deltaTime * movementSpeed;
        }

        //destroy enemy by pressing space
        if (hitSomething && Input.GetKeyDown(KeyCode.Space))
        {
            hits += 1;
            Debug.Log(hits);
            enemyHealth = enemyHealth - 10;
            //healthText.text = "Enemy health: " + enemyHealth.ToString();

            SetHitText();
        }
    }

    private void SetHitText()
    {
        countText.text = "Hits: " + hits.ToString();
    }

    private void SetHealthText()
    {
        yourHealthText.text = "Your health: " + yourHealth.ToString();
    }

    private void SetEnemyText()
    {
        countText.text = "Hits: " + hits.ToString();
    }
}

//Raycast Script
//if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left) * 250, out hit, 100))
//{
//    Debug.Log("Hit Something");
//    hitSomething = true;
//    Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.left) * 250, Color.green, 5);
//}
//else
//{
//    Debug.Log("Nothing Hit");
//    Debug.DrawLine(this.transform.position, this.transform.TransformDirection(Vector3.left) * 250, Color.black, 5);
//}
