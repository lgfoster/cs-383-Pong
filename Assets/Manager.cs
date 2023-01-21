using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 botLeft, topRight;

    // Start is called before the first frame update
    void Start()
    {
        // Converts the pixel coordinates to the game's coordinates
        botLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0,0));
        topRight = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));

        Paddle paddle1 = Instantiate (paddle) as Paddle;
        Paddle paddle2 = Instantiate (paddle) as Paddle;

        paddle1.Init (true);
        paddle2.Init (false);
    }

    // Update is called once per frame
    void Update()
    {
        // Quit game
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting Game\n");
            Application.Quit();
        }

        // Generate new ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate (ball);
        }
    }
}
