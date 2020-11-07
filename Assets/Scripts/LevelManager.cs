using UnityEngine;

public class LevelManager : MonoBehaviour {
    [System.Serializable]
    public struct Level {
        public Enemy[] minions;
        public float minionsSpawnInterval;

        public Enemy boss;
        public float bossSpawnTime;
    }

    public class LevelState {
        public int levelIndex;
        public Level level;
        public float startTime;

        public bool bossSpawned;
        public float lastMinionSpawnTime;

        public LevelState(int levelIndex, Level[] levels) {
            this.levelIndex = levelIndex;
            this.level = levels[levelIndex];
            this.startTime = Time.time;

            this.bossSpawned = false;
            // so that minions will spawn straightaway
            this.lastMinionSpawnTime = this.startTime - this.level.minionsSpawnInterval;
        }
    }

    private PlayerController player;

    public Level[] levels;
    private LevelState levelState;

    void Start() {
        player = FindObjectOfType<PlayerController>();

        Debug.Assert(levels != null && levels.Length > 0, "There are no levels.'");
        levelState = new LevelState(0, levels);
    }

    void StartNextLevel() {
        Debug.Assert(levelState.levelIndex + 1 < levels.Length, "No more levels to go to.");
        levelState = new LevelState(levelState.levelIndex + 1, levels);
    }

    void Update() {
        if (!levelState.bossSpawned && Time.time - levelState.startTime > levelState.level.bossSpawnTime) {
            SpawnBoss();
        }
        if (Time.time - levelState.lastMinionSpawnTime > levelState.level.minionsSpawnInterval) {
            SpawnMinions();
        }
    }

    Vector2 GetRandomSpawnPosition() {
        float randomAngle = Random.Range(0.0f, Mathf.PI * 2);

        Vector2 randomDirection = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle));

        // TODO: Better way of generating position?
        return (Vector2)player.transform.position + (randomDirection * 25.0f);
    }

    void SpawnBoss() {
        levelState.bossSpawned = true;

        Debug.Assert(levelState.level.boss != null, "No boss prefab to spawn.");
        Instantiate(levelState.level.boss.gameObject, GetRandomSpawnPosition(), Quaternion.identity);
    }

    void SpawnMinions() {
        levelState.lastMinionSpawnTime = Time.time;

        Debug.Assert(levelState.level.minions != null && levelState.level.minions.Length > 0, "No minions to spawn.");
        foreach (Enemy minion in levelState.level.minions) {
            Instantiate(minion.gameObject, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }
}
