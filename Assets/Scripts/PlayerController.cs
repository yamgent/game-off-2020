using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5;
    public Bullet bullet;
    public float bulletSpeed = 50;

    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveX = x * moveSpeed;
        float moveY = y * moveSpeed;

        rb2d.velocity = new Vector2(moveX, moveY);

        if (Input.GetMouseButtonDown(0)) {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Bullet bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletObject.SetVelocity(clickPosition - transform.position, bulletSpeed);
        }
    }
}
