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

        // ÿ��һ��ʱ��ͻ����ɹ���
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
        // ���ȷ�����ɹ����λ��
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        // ���ɹ�����Ϸ����
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);

        // �����ɵĹ���ת�Ƶ���ĸ����
        newEnemy.transform.parent = transform;
    }

    // �漴ȷ����������λ�þ������ʵ�֣������ɵĹ��ﲻ��ֱ�ӳ����������Ұ��Χ��
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
