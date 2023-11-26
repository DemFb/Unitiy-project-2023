//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
//using UnityEngine;
//using UnityEngine.UI;

//public class SpawnEnemies : MonoBehaviour
//{
//    public List<GameObject> enemyPrefabs;
//    public GameObject bossPrefab;
//    public int startingEnemyCount = 5;
//    public float timeBetweenWaves = 5f;
//    public int bossWaveInterval = 5;

//    private int currentWave = 1;

//    public Text warningText;
//    public Text bossArrivedText;
//    public Text remainingEnemiesText;
//    public Text waveWarningText;

//    public enum EnemyType
//    {
//        Enemy,
//        Boss,
//    }

//    private List<GameObject> spawnedEnemies = new List<GameObject>();

//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(SpawnWaves());
//    }

//    IEnumerator SpawnWaves()
//    {
//        while (true)
//        {
//            float timeRemaining = timeBetweenWaves; // Initialiser le temps restant avec le temps entre les vagues

//            while (timeRemaining > 0)
//            {
//                waveWarningText.text = "Prochaine vague dans " + Mathf.CeilToInt(timeRemaining) + " secondes"; // Utiliser Mathf.CeilToInt pour arrondir à l'entier supérieur
//                yield return new WaitForSeconds(1f);
//                timeRemaining -= 1f;
//            }

//            waveWarningText.text = "";

//            int enemyCount = startingEnemyCount + currentWave * 2;
//            UpdateRemainingEnemiesText(enemyCount);

//            for (int i = 0; i < enemyCount; i++)
//            {
//                GameObject enemyPrefab = GetRandomEnemyPrefab();
//                GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
//                spawnedEnemies.Add(enemy);

//                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
//                if (enemyHealth != null)
//                {
//                    enemyHealth.OnDeath += HandleEnemyDeath;
//                }

//                yield return new WaitForSeconds(0.3f);
//            }


//            while (AreEnemiesAlive())
//            {
//                yield return null; // Attendez que tous les ennemis soient morts
//            }
//            currentWave++;

//            SpawnEnemy();



//            if (currentWave % bossWaveInterval == 0)
//            {
//                StartCoroutine(SpawnBoss());
//            }
//        }
//    }

//    void HandleEnemyDeath(int remainingEnemies)
//    {
//        // Mettre à jour la liste spawnedEnemies après la mort de l'ennemi
//        spawnedEnemies.RemoveAll(enemy => enemy == null || !enemy.activeSelf);
//        UpdateRemainingEnemiesText(remainingEnemies);

//        if (enemyType == EnemyType.Normal)
//        {
//            GameManager.instance.UpdateScore(5);
//        }
//        else if (enemyType == EnemyType.Boss)
//        {
//            GameManager.instance.UpdateScore(15);
//        }

//    }

//    EnemyType GetEnemyType(GameObject enemy)
//    {
//        if (enemy.CompareTag("Boss"))
//        {
//            return EnemyType.Boss;
//        }
//        // Ajoutez d'autres conditions pour différents types d'ennemis si nécessaire
//        else
//        {
//            // Retournez le type par défaut ou traitez le cas où le tag n'est pas reconnu
//            return EnemyType.Enemy;
//        }
//    }

//    bool AreEnemiesAlive()
//    {
//        return spawnedEnemies.Any(enemy => enemy != null && enemy.activeSelf);
//    }

//    void UpdateRemainingEnemiesText(int remainingEnemies)
//    {
//        remainingEnemiesText.text = "Enemies restants: " + remainingEnemies;
//    }

//    GameObject GetRandomEnemyPrefab()
//    {
//        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
//        return enemyPrefabs[randomEnemyIndex];
//    }

//    Vector3 GetRandomSpawnPosition()
//    {
//        float xPos = Random.Range(10, 140);
//        float zPos = Random.Range(10, 140);
//        return new Vector3(xPos, 3, zPos);
//    }

//    void SpawnEnemy()
//    {
//        GameObject enemyPrefab = GetRandomEnemyPrefab();
//        GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
//        spawnedEnemies.Add(enemy);

//        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
//        if (enemyHealth != null)
//        {
//            enemyHealth.OnDeath += HandleEnemyDeath;
//        }
//    }

//    IEnumerator SpawnBoss()
//    {
//        warningText.text = "ATTENTION: Un boss approche!";
//        yield return new WaitForSeconds(2f);
//        warningText.text = "";

//        GameObject boss = Instantiate(bossPrefab, GetRandomSpawnPosition(), Quaternion.identity);
//        spawnedEnemies.Add(boss);

//        BossHealth bossHealth = boss.GetComponent<BossHealth>();
//        if (bossHealth != null)
//        {
//            bossHealth.OnDeath += HandleEnemyDeath;
//        }

//        bossArrivedText.text = "Un boss est apparu!";
//        yield return new WaitForSeconds(3f);
//        bossArrivedText.text = "";
//    }
//}




using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public GameObject bossPrefab;
    public int startingEnemyCount = 5;
    public float timeBetweenWaves = 5f;
    public int bossWaveInterval = 5;

    private int currentWave = 1;

    public Text warningText;
    public Text bossArrivedText;
    public Text remainingEnemiesText;
    public Text waveWarningText;

    public enum EnemyType
    {
        Enemy,
        Boss,
    }

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            float timeRemaining = timeBetweenWaves; // Initialiser le temps restant avec le temps entre les vagues

            while (timeRemaining > 0)
            {
                waveWarningText.text = "Prochaine vague dans " + Mathf.CeilToInt(timeRemaining) + " secondes"; // Utiliser Mathf.CeilToInt pour arrondir à l'entier supérieur
                yield return new WaitForSeconds(1f);
                timeRemaining -= 1f;
            }

            waveWarningText.text = "";

            int enemyCount = startingEnemyCount + currentWave * 2;
            UpdateRemainingEnemiesText(enemyCount);

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemyPrefab = GetRandomEnemyPrefab();
                GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
                spawnedEnemies.Add(enemy);

                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.OnDeathCount += UpdateRemainingEnemiesText;
                    enemyHealth.OnDeathType += HandleEnemyDeathType;
                }

                yield return new WaitForSeconds(0.3f);
            }

            while (AreEnemiesAlive())
            {
                yield return null; // Attendez que tous les ennemis soient morts
            }

            currentWave++;
            SpawnEnemy();

            if (currentWave % bossWaveInterval == 0)
            {
                StartCoroutine(SpawnBoss());
            }
        }
    }

    void HandleEnemyDeathType(EnemyType enemyType)
    {
        if (enemyType == EnemyType.Enemy)
        {
            GameManager.instance.UpdateScore(5);
        }
        else if (enemyType == EnemyType.Boss)
        {
            GameManager.instance.UpdateScore(15);
        }
    }

    EnemyType GetEnemyType(GameObject enemy)
    {
        if (enemy.CompareTag("Boss"))
        {
            return EnemyType.Boss;
        }
        // Ajoutez d'autres conditions pour différents types d'ennemis si nécessaire
        else
        {
            // Retournez le type par défaut ou traitez le cas où le tag n'est pas reconnu
            return EnemyType.Enemy;
        }
    }

    bool AreEnemiesAlive()
    {
        return spawnedEnemies.Any(enemy => enemy != null && enemy.activeSelf);
    }

    void UpdateRemainingEnemiesText(int remainingEnemies)
    {
        remainingEnemiesText.text = "Enemies restants: " + remainingEnemies;
    }

    GameObject GetRandomEnemyPrefab()
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
        return enemyPrefabs[randomEnemyIndex];
    }

    Vector3 GetRandomSpawnPosition()
    {
        float xPos = Random.Range(10, 140);
        float zPos = Random.Range(10, 140);
        return new Vector3(xPos, 3, zPos);
    }

    void SpawnEnemy()
    {
        GameObject enemyPrefab = GetRandomEnemyPrefab();
        GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        spawnedEnemies.Add(enemy);

        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDeathCount += UpdateRemainingEnemiesText;
            enemyHealth.OnDeathType += HandleEnemyDeathType;
        }
    }

    IEnumerator SpawnBoss()
    {
        warningText.text = "ATTENTION: Un boss approche!";
        yield return new WaitForSeconds(2f);
        warningText.text = "";

        GameObject boss = Instantiate(bossPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        spawnedEnemies.Add(boss);

        BossHealth bossHealth = boss.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.OnDeathCount += UpdateRemainingEnemiesText;
        }

        bossArrivedText.text = "Un boss est apparu!";
        yield return new WaitForSeconds(3f);
        bossArrivedText.text = "";
    }
}
