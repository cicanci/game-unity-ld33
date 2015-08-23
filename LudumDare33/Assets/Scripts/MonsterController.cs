using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    public float speed = 10;

    void Start ()
    {
	
	}

    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    // Get movement of the finger since last frame
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        //    // Move object across XY plane
        //    transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Mathf.Abs(ray.origin.x - gameObject.transform.localPosition.x) > 0.1f)
        {
            if (ray.origin.x > gameObject.transform.localPosition.x)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            }
            else if (ray.origin.x < gameObject.transform.localPosition.x)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            }
        }

        if (Mathf.Abs(ray.origin.y - gameObject.transform.localPosition.y) > 0.1f)
        {
            if (ray.origin.y > gameObject.transform.localPosition.y)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + (Time.deltaTime * speed), gameObject.transform.localPosition.z);
            }
            else if (ray.origin.y < gameObject.transform.localPosition.y)
            {
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - (Time.deltaTime * speed), gameObject.transform.localPosition.z);
            }
        }
    }

    void LateUpdate()
    {
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float top = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        float bottom = Camera.main.ViewportToWorldPoint(Vector3.one).y;

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        if (gameObject.transform.position.x <= left + gameObject.GetComponent<Renderer>().bounds.extents.x)
        {
            x = left + gameObject.GetComponent<Renderer>().bounds.extents.x;
        }
        else if (gameObject.transform.position.x >= right - gameObject.GetComponent<Renderer>().bounds.extents.x)
        {
            x = right - gameObject.GetComponent<Renderer>().bounds.extents.x;
        }

        if (gameObject.transform.position.y <= top + gameObject.GetComponent<Renderer>().bounds.extents.y)
        {
            y = top + gameObject.GetComponent<Renderer>().bounds.extents.y;
        }
        else if (gameObject.transform.position.y >= bottom - gameObject.GetComponent<Renderer>().bounds.extents.y)
        {
            y = bottom - gameObject.GetComponent<Renderer>().bounds.extents.y;
        }

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
