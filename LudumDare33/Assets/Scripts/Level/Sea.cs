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
        float sizeY = sea.GetComponent<Renderer>().bounds.size.y;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject tile = Instantiate(sea);

                if (j % 2 == 0)
                {
                    tile.transform.localPosition = new Vector3(sizeX * i, sizeY * j, 0);
                }
                else
                {
                    tile.transform.localPosition = new Vector3(sizeX * i + (sizeX * 0.5f), sizeY * j - (sizeY * 0.25f), 0);
                }
            }
        }
    }

    void Update()
    {

    }
}
