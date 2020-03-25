using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float radius { protected set; get; }
    protected Vector2 world_size;
    protected SpriteRenderer spriteRenderer;

    public float leftBorder { get; protected set; } // () { return (transform.position.x - radius); }
    public float rightBorder { get; protected set; } // () { return transform.position.x + radius; }
    public float upBorder { get; protected set; } // () { return transform.position.y + radius; }
    public float downBorder { get; protected set; } // () { return transform.position.y - radius; }

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 sprite_size = spriteRenderer.sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / spriteRenderer.sprite.pixelsPerUnit;
        world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        SetRadius();
        SetBorder();
    }

    protected virtual void SetRadius()
    {
        radius = Mathf.Sqrt(world_size.x * world_size.x + world_size.y * world_size.y) / 2;
    }

    protected virtual void SetBorder()
    {
        leftBorder = transform.position.x - world_size.x / 2;
        rightBorder = transform.position.x + world_size.x / 2;
        upBorder = transform.position.y + world_size.y / 2;
        downBorder = transform.position.y - world_size.y / 2;
    }
}
