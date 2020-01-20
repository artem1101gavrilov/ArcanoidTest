using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 world_size;
    public Vector3 WorldSize { get { return world_size; } }
    public float Radius { private set; get; }

    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 sprite_size = spriteRenderer.sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / spriteRenderer.sprite.pixelsPerUnit;
        world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        Radius = Mathf.Sqrt(WorldSize.x * WorldSize.x + WorldSize.y * WorldSize.y) / 2;
    }
}
