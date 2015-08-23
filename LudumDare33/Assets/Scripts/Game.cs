using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public GameObject monster;
    public GameObject blueBoat;
    public float speed = 10;

    void Start()
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

        if (Mathf.Abs(ray.origin.x - monster.transform.localPosition.x) > 0.1f)
        {
            if (ray.origin.x > monster.transform.localPosition.x)
            {
                monster.transform.localPosition = new Vector3(monster.transform.localPosition.x + (Time.deltaTime * speed), monster.transform.localPosition.y, monster.transform.localPosition.z);
            }
            else if (ray.origin.x < monster.transform.localPosition.x)
            {
                monster.transform.localPosition = new Vector3(monster.transform.localPosition.x - (Time.deltaTime * speed), monster.transform.localPosition.y, monster.transform.localPosition.z);
            }
        }

        if (Mathf.Abs(ray.origin.y - monster.transform.localPosition.y) > 0.1f)
        {
            if (ray.origin.y > monster.transform.localPosition.y)
            {
                monster.transform.localPosition = new Vector3(monster.transform.localPosition.x, monster.transform.localPosition.y + (Time.deltaTime * speed), monster.transform.localPosition.z);
            }
            else if (ray.origin.y < monster.transform.localPosition.y)
            {
                monster.transform.localPosition = new Vector3(monster.transform.localPosition.x, monster.transform.localPosition.y - (Time.deltaTime * speed), monster.transform.localPosition.z);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (monster.GetComponent<Renderer>().bounds.Intersects(blueBoat.GetComponent<Renderer>().bounds))
            {
                Debug.Log("ATTACK!");
                Destroy(blueBoat);
            }
            else
            {
                Debug.Log("NOPE!");
            }
        }
    }

    void LateUpdate()
    {
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float top = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        float bottom = Camera.main.ViewportToWorldPoint(Vector3.one).y;

        float x = monster.transform.position.x;
        float y = monster.transform.position.y;

        if (monster.transform.position.x <= left + monster.GetComponent<Renderer>().bounds.extents.x)
        {
            x = left + monster.GetComponent<Renderer>().bounds.extents.x;
        }
        else if (monster.transform.position.x >= right - monster.GetComponent<Renderer>().bounds.extents.x)
        {
            x = right - monster.GetComponent<Renderer>().bounds.extents.x;
        }

        if (monster.transform.position.y <= top + monster.GetComponent<Renderer>().bounds.extents.y)
        {
            y = top + monster.GetComponent<Renderer>().bounds.extents.y;
        }
        else if (monster.transform.position.y >= bottom - monster.GetComponent<Renderer>().bounds.extents.y)
        {
            y = bottom - monster.GetComponent<Renderer>().bounds.extents.y;
        }

        monster.transform.position = new Vector3(x, y, monster.transform.position.z);
    }
}
