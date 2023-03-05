using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpamEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject enemy_0;
    [SerializeField]
    GameObject enemy_1;
    [SerializeField]
    GameObject enemy_2;
    [SerializeField]
    GameObject enemy_3;
    [SerializeField]
    GameObject enemy_4;

    [SerializeField]
    int MaxEnemyCount;

    [SerializeField]
    float GeneralSpawnTime;

    [SerializeField]
    float PrepareTime;

    float TimeSpawnNormalEnemy;
    float TimeSpawnBoss;

    [SerializeField]
    Tilemap tilemap;

    float screenLeft, screenTop, screenRight, screenBottom;
    float TimeNormalEnemy;
    float TimeBoss;
    List<GameObject> NormalEnemies;

    // Start is called before the first frame update
    void Start()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        NormalEnemies = new List<GameObject>{
                enemy_0,
                enemy_1,
                enemy_2,
                enemy_4
        };

        TimeSpawnNormalEnemy = GeneralSpawnTime * 0.5f;
        TimeSpawnBoss = GeneralSpawnTime * 20;

        TimeNormalEnemy = -PrepareTime;
        TimeBoss = -PrepareTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeNormalEnemy += Time.deltaTime;
        TimeBoss += Time.deltaTime;

        SpawnEnemyWhenAllowed(ref TimeNormalEnemy, TimeSpawnNormalEnemy, null);
        SpawnEnemyWhenAllowed(ref TimeBoss, TimeSpawnBoss, enemy_3);
    }

    Vector3 GetRandomWorldPosition()
    {
        Vector3Int RandomPosition = new Vector3Int(
            Random.Range(tilemap.cellBounds.min.x + 1, tilemap.cellBounds.max.x - 1), 
            Random.Range(tilemap.cellBounds.min.y + 1, tilemap.cellBounds.max.y - 1),
            0);
        Vector3 RandomWorldPosition = tilemap.CellToWorld(RandomPosition) + new Vector3(0.5f, 0.5f, 0);
        return RandomWorldPosition;
    }

    void SpawnEnemyWhenAllowed(ref float time, float timeSpawn, GameObject enemyGameObject)
    {
        int CurrentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (time >= timeSpawn && CurrentEnemiesCount < MaxEnemyCount)
        {
            GameObject enemy = Instantiate(enemyGameObject == null ? GetRandomNormalEnemy() : enemyGameObject);
            enemy.transform.position = GetRandomWorldPosition();
            time = 0;
        }
    }

    GameObject GetRandomNormalEnemy()
    {
        int index = Random.Range(0, NormalEnemies.Count + 1);
        if(index == 4) return NormalEnemies[3];
        else return NormalEnemies[index];
    }
}
