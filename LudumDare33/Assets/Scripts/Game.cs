using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject monster;
    public GameObject boatPrefab;
    public float spawnDelay;

    private Command buttonDown;
    private Command buttonLeft;
    private Command buttonRight;
    private Command buttonUp;
    private Command buttonAttack;
    private Spawner boatSpawner;
    private float spawnCount;
    private int currentScore;

    void Start()
    {
        buttonDown = new MoveDownCommand();
        buttonLeft = new MoveLeftCommand();
        buttonRight = new MoveRightCommand();
        buttonUp = new MoveUpCommand();
        buttonAttack = new AttackCommand();

        boatSpawner = new Spawner(boatPrefab);
    }

    void Update()
    {
        HandleInput();

        SpawnBoat();
    }

    private void HandleInput()
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
                buttonRight.Execute(monster);
            }
            else if (ray.origin.x < monster.transform.localPosition.x)
            {
                buttonLeft.Execute(monster);
            }
        }

        if (Mathf.Abs(ray.origin.y - monster.transform.localPosition.y) > 0.1f)
        {
            if (ray.origin.y > monster.transform.localPosition.y)
            {
                buttonUp.Execute(monster);
            }
            else if (ray.origin.y < monster.transform.localPosition.y)
            {
                buttonDown.Execute(monster);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            buttonAttack.Execute(monster);
        }
    }

    private void SpawnBoat()
    {
        if (spawnCount < spawnDelay)
        {
            spawnCount += Time.deltaTime;
        }

        if (spawnCount >= spawnDelay)
        {
            Vector3 position = Vector3.zero;

            switch (Random.Range(0, 4))
            {
                case 0:
                    position = new Vector3(Random.Range(-10, 10), 7, 0);
                    break;
                case 1:
                    position = new Vector3(Random.Range(-10, 10), -7, 0);
                    break;
                case 2:
                    position = new Vector3(10, Random.Range(-7, 7), 0);
                    break;
                case 3:
                    position = new Vector3(-10, Random.Range(-7, 7), 0);
                    break;
                default:
                    break;
            }

            GameObject boat = boatSpawner.SpawnObject();
            boat.transform.localPosition = position;
            spawnCount = 0;
        }
    }
}
