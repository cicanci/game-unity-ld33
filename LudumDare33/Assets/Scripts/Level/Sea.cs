using UnityEngine;
using System.Collections;

public class Sea : MonoBehaviour
{
    public GameObject sea;
    public int width;
    public int height;

    void Start()
    {
        float sizeX = sea.GetComponent<Renderer>().bounds.size.x;
        float sizeY = sea.GetComponent<Renderer>().bounds.size.y * 0.75f;

        float startX = (sizeX * (width * 0.5f)) - sizeX;
        float startY = (sizeY * (height * 0.5f)) - sizeY;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject tile = Instantiate(sea);
                tile.transform.parent = transform;

                if (j % 2 == 0)
                {
                    tile.transform.localPosition = new Vector3(startX - (sizeX * i), startY - (sizeY * j), 0);
                }
                else
                {
                    tile.transform.localPosition = new Vector3(startX - (sizeX * i + (sizeX * 0.5f)), startY - (sizeY * j), 0);
                }
            }
        }
    }

    void Update()
    {

    }
}
