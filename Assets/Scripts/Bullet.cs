using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public void SetVelocity(Vector3 moveDirection, float moveSpeed) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * moveSpeed;
    }

}
