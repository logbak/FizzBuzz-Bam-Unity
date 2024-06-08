using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour

{
    public float speed;
    public Rigidbody2D projectile;

    void Start()
    {
        projectile.velocity = Vector2.up * speed;
    }

}
