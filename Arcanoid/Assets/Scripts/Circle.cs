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
    protected const float downBorderMap = -4.7f;

    //TODO: Массив всех кубов и ракетки
    [SerializeField] private GameObject bonus;
    [SerializeField] private List<Cube> cubes;
    [SerializeField] protected Paddle paddle;

    protected override void Start()
    {
        base.Start();
        SetDirection(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    protected override void SetRadius()
    {
        radius = world_size.x / 2;
    }

    protected override void SetBorder()
    {
        leftBorder = transform.position.x - radius;
        rightBorder = transform.position.x + radius;
        upBorder = transform.position.y + radius;
        downBorder = transform.position.y - radius;
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
        SetBorder();
    }

    protected virtual void Colissions()
    {
        CheckBorder();
        if (CheckCubes())
        {
            CheckPaddle();
        }
    }

    protected virtual void CheckBorder()
    {
        if (leftBorder < leftBorderMap)
        {
            SetDirection(Random.Range(0.0f, 1.0f), direction.y);
        }
        else if (upBorder > upBorderMap)
        {
            SetDirection(direction.x, Random.Range(-1.0f, 0.0f));
        }
        else if (rightBorder > rightBorderMap)
        {
            SetDirection(Random.Range(-1.0f, 0.0f), direction.y);
        }
        else if (downBorder < downBorderMap)
        {
            //TODO: GameOver
        }
    }

    private bool CheckCubes()
    {
        var destroyCubes = cubes.Where(x => Distance(FindBorderPoint(x)) < (Mathf.Pow(radius, 2))).ToList();
        int i;
        for (i = 0; i < destroyCubes.Count; ++i)
        {
            //TODO: Проверки на точку соприкосновения (8 случаев)
            var cube = destroyCubes[i];
            ChangeDirectionInCollision(cube);
            cubes.Remove(cube);
            var b = Instantiate(bonus, cube.transform.position, Quaternion.identity);
            b.GetComponent<Bonus>().SetPaddle(paddle);
            Destroy(cube.gameObject);
        }
        if (i > 0) return false;
        return true;
    }

    protected void CheckPaddle()
    {
        var touch = Distance(FindBorderPoint(paddle)) < (Mathf.Pow(radius, 2));
        //TODO: Проверки на соприкосновения
        if (touch)
        {
            CollisionPaddle(paddle);
        }
    }

    private float Distance(Vector3 cube)
    {
        return Mathf.Pow(cube.x - transform.position.x, 2) + Mathf.Pow(cube.y - transform.position.y, 2);
    }

    private Vector3 FindBorderPoint(Cube cube)
    {
        Vector3 border = new Vector3(cube.leftBorder, cube.downBorder, 0);
        if (transform.position.x > border.x)
        {
            if (transform.position.x > cube.rightBorder)
            {
                border.x = cube.rightBorder;
            }
            else
            {
                border.x = transform.position.x;
            }
        }
        if (transform.position.y > border.y)
        {
            if (transform.position.y > cube.upBorder)
            {
                border.y = cube.upBorder;
            }
            else
            {
                border.y = transform.position.y;
            }
        }
        return border;
    }

    protected virtual void CollisionPaddle(Paddle paddle)
    {
        ChangeDirectionInCollision(paddle);
    }

    private void ChangeDirectionInCollision(Cube cube)
    {
        var pos = FindBorderPoint(cube);
        //Между длиной
        if (pos.x > cube.leftBorder && pos.x < cube.rightBorder)
        {
            SetDirection(direction.x, -direction.y);
        }
        //Между высотой
        else if (pos.y > cube.downBorder && pos.y < cube.upBorder)
        {
            SetDirection(-direction.x, direction.y);
        }
        //углы
        else
        {
            SetDirection(-direction.x, -direction.y);
        }
    }

    protected void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
        direction.Normalize();
    }
}