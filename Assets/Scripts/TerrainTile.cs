using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObjects;

    private void Start()
    {
        GetComponentInParent<WorldScorlling>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, -100, 0);
    }

    // ������������������õ���Ϸ����
    public void Spawn()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }

}
