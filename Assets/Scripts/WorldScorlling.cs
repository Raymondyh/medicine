using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScorlling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0, 0);
    [SerializeField] Vector2Int playerTilePosition;
    // Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 78f;

    GameObject[,] terrainTiles;

    // 设置每行每列的瓦片数
    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Start()
    {
        UpdateTileOnScreen();
    }

    private void Update()
    {
        // 持续更新玩家所在地图坐标索引
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        // 修正玩家负半轴上行动后所在的地图坐标索引
        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            // onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            // onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);
            
            // 根据玩家位置更新玩家位置所在对应的地图索引
            UpdateTileOnScreen();
        }
    }

    private void UpdateTileOnScreen()
    {
        // 遍历所有瓦片的索引，找到需要变化的瓦片，并更新其位置
        for (int pov_x = -(fieldOfVisionWidth / 2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight / 2); pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                Vector3 newPosition = CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
                // 随机更新场景物体
                if (newPosition != tile.transform.position)
                {
                    tile.transform.position = newPosition;
                    terrainTiles[tileToUpdate_x, tileToUpdate_y].GetComponent<TerrainTile>().Spawn();
                }
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        // 根据玩家位置确定移动地图瓦片的索引
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount -1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount -1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        // 将瓦片这个游戏物体和位置进行赋值
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
