using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Vector3 world_size;
    float radius;
    //TODO: Массив всех кубов и ракетки

    void Start ()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 sprite_size = spriteRenderer.sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / spriteRenderer.sprite.pixelsPerUnit;
        world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        radius = world_size.x / 2;
    }
	
	void Update ()
    {
		//TODO: Движение
        //TODO: Проверка коллизий
	}
}
