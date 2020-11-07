using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public void SetVelocity(Vector3 moveDirection, float moveSpeed) {
        GetComponent<Rigidbody2D>().velocity = moveDirection.normalized * moveSpeed;
    }
    
}
