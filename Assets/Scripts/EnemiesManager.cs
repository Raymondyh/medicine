using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    [SerializeField] GameObject AI_1;
    [SerializeField] GameObject Cold_1;
    [SerializeField] GameObject AI_3;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] public float spawnTime;
    [SerializeField] GameObject player;
    public bool isAI_1;
    public bool isAI_2;
    public bool isAI_3;
    float _timer;

    private void Awake()
    {
        isAI_1 = false;
        isAI_2 = false;
        isAI_3 = false;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        // 每隔一段时间就会生成怪物
        if (_timer < 0f)
        {
            SpawnEnemy(AI_1);
            if(isAI_1)
            {
                SpawnEnemy(AI_1);
            }
            if (isAI_2)
            {
                SpawnEnemy(Cold_1);
            }
            if (isAI_3)
            {
                SpawnEnemy(AI_1);
                SpawnEnemy(Cold_1);
                SpawnEnemy(AI_3);
            }
            _timer = spawnTime;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        // 随机确定生成怪物的位置
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        // 生成怪物游戏物体
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);

        // 将生成的怪物转移到父母体上
        newEnemy.transform.parent = transform;
    }

    // 随即确定怪物生成位置具体代码实现，且生成的怪物不会直接出现在玩家视野范围内
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0f;

        return position;
    }
}
