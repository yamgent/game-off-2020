using UnityEngine;

public class Enemy : MonoBehaviour {
    private PlayerController player;
    public float speed = 10.0f;
    public float keepDistance = 5.0f;

    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    void MoveTowardsPlayer() {
        Vector2 towardsPlayer = (Vector2)(player.transform.position - transform.position);

        if (towardsPlayer.sqrMagnitude < Mathf.Pow(keepDistance, 2.0f)) {
            return;
        }
        towardsPlayer.Normalize();

        transform.position += (Vector3)(towardsPlayer * speed * Time.deltaTime);
    }

    void Update() {
        MoveTowardsPlayer();
    }
}
