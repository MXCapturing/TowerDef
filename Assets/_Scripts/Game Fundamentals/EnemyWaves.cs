using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour {

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
    private int nextWave = 0;

    public float waveCountdown;

    private float searchCountdown = 1f;

    public Animator playerAnim;

    public SpawnState state = SpawnState.Shopping;

    private void Start()
    {
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
                if (state != SpawnState.Spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
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

        playerAnim.SetBool("FadeOut", true);
        Invoke("FadeOutFalse", 1f);

        nextWave++;
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

    IEnumerator SpawnWave(Waves _wave)
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

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
