/*    
  Copyright (C) 2026 Narratech Laboratories
  https://www.narratech.com
  Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
  Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
  Autor: Federico Peinado 
  Contacto: email@federicopeinado.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRespawnManager : MonoBehaviour
{
    public static EnemyRespawnManager Instance;

    [Header("Referencias")]
    public EnemySpawnPoints spawnPoints;

    [Header("Prefabs")]
    public List<GameObject> enemyPrefabs;

    [Header("Settings")]
    public float respawnDelay = 3f;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EnemyManager.OnEnemyKilled += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        EnemyManager.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void HandleEnemyKilled(GameObject enemy)
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints.GetRandomSpawnPoint();

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}