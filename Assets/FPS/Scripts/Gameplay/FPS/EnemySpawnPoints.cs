/*    
  Copyright (C) 2026 Narratech Laboratories
  https://www.narratech.com
  Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
  Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
  Autor: Federico Peinado 
  Contacto: email@federicopeinado.com
*/

using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    public Transform GetRandomSpawnPoint()
    {
        if (spawnPoints.Length <= 1) return transform;

        int index = Random.Range(1, spawnPoints.Length); // evita el padre
        return spawnPoints[index];
    }
}