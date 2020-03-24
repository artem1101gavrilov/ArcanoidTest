using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float radius { protected set; get; }
    protected Vector2 world_size;

    protected float leftBorder() { return (transform.position.x - radius); }
    protected float rightBorder() { return transform.position.x + radius; }
    protected float upBorder() { return transform.position.y + radius; }
    protected float downBorder() { return transform.position.y - radius; }

    protected virtual void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 sprite_size = spriteRenderer.sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / spriteRenderer.sprite.pixelsPerUnit;
        world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        SetRadius();
    }

    protected virtual void SetRadius()
    {
        radius = Mathf.Sqrt(world_size.x * world_size.x + world_size.y * world_size.y) / 2;
    }
}
