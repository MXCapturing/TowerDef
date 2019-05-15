using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

    public static EnemyWaves instance;

    public enum SpawnState { Spawning, Waiting, Counting, Shopping };

    [System.Serializable]
    public class Waves
    {
        public string waveName;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Waves[] waves;
    public int nextWave = 0;

    public int enemyHP;
    public int enemyDamage;
    public float enemyDelay;
    public float enemySpeed;

    public int waveReward;

    public int randomSpawn;
    public int randomSpawnMax = 1;
    public Transform[] spawnpoints;

    public float waveCountdown;

    private float searchCountdown = 1f;

    public Animator playerAnim;

    public SpawnState state = SpawnState.Shopping;

    private void Start()
    {
        instance = this;
        waveCountdown = 5f;
    }

    private void FixedUpdate()
    {
        if(state != SpawnState.Shopping)
        {
            if(state == SpawnState.Waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.Spawning && nextWave <= 4)
                {
                    StartCoroutine(SpawnTutorialWave(waves[nextWave]));
                }
                else if(state != SpawnState.Spawning && nextWave > 4)
                {
                    StartCoroutine(SpawnWaves(waves[5]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.Shopping;
        waveCountdown = 5f;

        BulletNumbers.instance.pistolBulletsInGun = BulletNumbers.instance.pistolMaxInGun;
        BulletNumbers.instance.shotgunBulletsInGun = BulletNumbers.instance.shotgunMaxInGun;
        BulletNumbers.instance.sniperBulletsInGun = BulletNumbers.instance.sniperMaxInGun;

        Currency.instance.money += waveReward;
        waveReward += 50;

        playerAnim.SetBool("FadeOut", true);
        Invoke("FadeOutFalse", 1f);

        nextWave++;
        if(nextWave % 5 == 0)
        {
            if(randomSpawnMax < 6)
            {
                randomSpawnMax++;
            }
            enemyHP += 10;
            enemyDamage += 5;
            enemyDelay -= 0.2f;
            enemySpeed += 0.2f;
        }
        if(nextWave > 5)
        {
            waves[5].count += 2;
        }
    }

    void FadeOutFalse()
    {
        playerAnim.SetBool("FadeOut", false);
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnTutorialWave(Waves _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.waveName);
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    IEnumerator SpawnWaves(Waves _wave_)
    {
        Debug.Log("Spawning Wave: " + nextWave);
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave_.count; i++)
        {
            SpawnEnemy(_wave_.enemy);
            yield return new WaitForSeconds(1f / _wave_.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        randomSpawn = Random.Range(0, randomSpawnMax);
        Instantiate(_enemy, spawnpoints[randomSpawn].position, transform.rotation);
    }
}
