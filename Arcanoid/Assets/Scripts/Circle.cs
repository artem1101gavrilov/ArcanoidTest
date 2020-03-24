using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Circle : Cube
{
    private Vector2 direction;
    private float speed = 4;
    
    private const float leftBorderMap = -2.5f;
    private const float rightBorderMap = 2.5f;
    private const float upBorderMap = 4.7f;
    private const float downBorderMap = -4.7f;

    //TODO: Массив всех кубов и ракетки
    [SerializeField] private List<Cube> cubes;
    [SerializeField] private Paddle paddle;

    protected override void Start()
    {
        base.Start();
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    protected override void SetRadius()
    {
        radius = world_size.x / 2;
    }
    
    private void Update()
    {
        //TODO: Движение
        Move();
        //TODO: Проверка коллизий
        Colissions();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Colissions()
    {
        CheckBorder();
        if (CheckCubes())
        {
            CheckPaddle();
        }
    }
    
    private void CheckBorder()
    {
        if (leftBorder() < leftBorderMap)
        {
            direction.x = Random.Range(0.0f, 1.0f);
        }

        else if (upBorder() > upBorderMap)
        {
            direction.y = Random.Range(-1.0f, 0.0f);
        }

        else if (rightBorder() > rightBorderMap)
        {
            direction.x = Random.Range(-1.0f, 0.0f);
        }

        else if (downBorder() < downBorderMap)
        {
            //TODO: GameOver
        }
    }
    
    private bool CheckCubes()
    {
        var destroyCubes = cubes.Where(x => Distance(x.transform.position) < (Mathf.Pow(radius + x.radius, 2))).ToList();

        int i;
        for (i = 0; i < destroyCubes.Count; ++i)
        {
            //TODO: Проверки на соприкосновения
            var cube = destroyCubes[i];
            cubes.Remove(cube);
            Destroy(cube.gameObject);
        }

        if (i > 0) return false;
        return true;
    }
    
    private void CheckPaddle()
    {
        var touch = Distance(paddle.transform.position) < (Mathf.Pow(radius + paddle.radius, 2));

        //TODO: Проверки на соприкосновения
        if (touch)
        {
            direction.y = Random.Range(0.0f, 1.0f);
        }
    }



    private float Distance(Vector3 cube)
    {
        return Mathf.Pow(cube.x - transform.position.x, 2) + Mathf.Pow(cube.y - transform.position.y, 2);
    }
}