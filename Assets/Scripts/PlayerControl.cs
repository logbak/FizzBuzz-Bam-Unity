using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //allows the contained properties to be viewed/edited in Unity inspector
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Rigidbody2D player;
    public Boundary boundary;

    void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;

        player.position = new Vector2
        (
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax)
        );
    }

}
