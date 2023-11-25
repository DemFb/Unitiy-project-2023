using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Vector3 position = Random.insideUnitSphere;
            CreateEnemy(position);
        }
        
    }

    private void CreateEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
