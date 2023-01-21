using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;
    
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool rightPaddle)
    {
        isRight = rightPaddle;
        
        Vector2 pos = Vector2.zero;
        
        if(rightPaddle)
        {
            pos = new Vector2(Manager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "RightPaddle";
        }
        else
        {
            pos = new Vector2(Manager.botLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "LeftPaddle";
        }

        // Update paddles position with transform 
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed; // Get axis is a number that is between -1 and 1

        if(transform.position.y < Manager.botLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        if(transform.position.y > Manager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate (move * Vector2.up);
    }
}
