using UnityEngine;
using System.Collections;

public class Boat : Character
{
    public Sprite blueBoat;
    public Sprite greenBoat;
    public Sprite redBoat;
    public Sprite yellowBoat;
    
    void Start ()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = blueBoat;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = greenBoat;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = redBoat;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = yellowBoat;
                break;
            default:
                break;
        }
    }
	
	void Update ()
    {
        bool moved = false;

        if (Mathf.Abs(gameObject.transform.localPosition.x) > 1)
        {
            if (gameObject.transform.localPosition.x > 0)
            {
                MoveLeft();
            }
            else if (gameObject.transform.localPosition.x < 0)
            {
                MoveRight();
            }

            moved = true;
        }

        if (Mathf.Abs(gameObject.transform.localPosition.y) > 1)
        {
            if (gameObject.transform.localPosition.y > 0)
            {
                MoveDown();
            }
            else if (gameObject.transform.localPosition.y < 0)
            {
                MoveUp();
            }

            moved = true;
        }

        if (moved)
        {
            Vector3 moveDirection = gameObject.transform.position - Vector3.zero;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else
        {
            Game.instance.GameOver();
        }
    }
}
