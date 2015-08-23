using UnityEngine;
using System.Collections;

public partial class Character : MonoBehaviour
{
    public float speed;

    private Collider2D other;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER: " + other.tag);
        this.other = other;
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log("STAY: " + other.tag);
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("EXIT: " + other.tag);
        this.other = null;
    }

    public void Attack()
    {
        if (other != null)
        {
            Destroy(other.gameObject);
        }
    }

    public void MoveRight()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

    public void MoveLeft()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

    public void MoveUp()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + (Time.deltaTime * speed), gameObject.transform.localPosition.z);
    }

    public void MoveDown()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - (Time.deltaTime * speed), gameObject.transform.localPosition.z);
    }
}
