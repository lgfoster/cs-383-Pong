using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed, radius;

    bool struckOnce;

    Vector2 direction = new Vector2(0.0f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
        direction = Random.insideUnitCircle.normalized;
        radius = transform.localScale.x / 2;
        struckOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Ball bounces off the top and bottom 
        if(transform.position.y < Manager.botLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if(transform.position.y > Manager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;   
        }

        // Left and right boundaries 
        if(transform.position.x < Manager.botLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Left screen goal\n");
            Destroy(gameObject);
            
            // Update Player 2's score
            ScoreManager.instance.AddPointsP2();
        }

        if(transform.position.x > Manager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Right screen goal\n");
            Destroy(gameObject);
            
            // Update Player 1's score
            ScoreManager.instance.AddPointsP1();
        }
    }

    // Collision function 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle> ().isRight;
            
            if(isRight && direction.x > 0 && struckOnce)
            {
                direction.x = -direction.x * 1.1f;
                Debug.Log("Right\n");
            }
            else if(isRight && direction.x > 0)
            {
                direction.x = -direction.x * 2;
                Debug.Log("Right\n");
                struckOnce = true;
            }

            if(!isRight && direction.x < 0 && struckOnce)
            {
                direction.x = -direction.x * 1.1f;
                Debug.Log("Left\n");
            }
            else if(!isRight && direction.x < 0)
            {
                direction.x = -direction.x * 2;
                Debug.Log("Left\n");
                struckOnce = true;
            }
        }
    }
}
