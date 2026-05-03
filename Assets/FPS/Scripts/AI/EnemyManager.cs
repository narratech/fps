/*    
  Copyright (C) 2026 Narratech Laboratories
  https://www.narratech.com
  Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
  Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
  Autor: Federico Peinado 
  Contacto: email@federicopeinado.com
*/
using System;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class EnemyManager : MonoBehaviour
    {

        // Idea para luego respawnear
        public static event Action<GameObject> OnEnemyKilled;

        public List<EnemyController> Enemies { get; private set; }
        public int NumberOfEnemiesTotal { get; private set; }
        public int NumberOfEnemiesRemaining => Enemies.Count;

        void Awake()
        {
            Enemies = new List<EnemyController>();
        }

        public void RegisterEnemy(EnemyController enemy)
        {
            Enemies.Add(enemy);

            NumberOfEnemiesTotal++;
        }

        public void UnregisterEnemy(EnemyController enemyKilled)
        {
            int enemiesRemainingNotification = NumberOfEnemiesRemaining - 1;

            EnemyKillEvent evt = Events.EnemyKillEvent;
            evt.Enemy = enemyKilled.gameObject;
            evt.RemainingEnemyCount = enemiesRemainingNotification;
            EventManager.Broadcast(evt);

            // removes the enemy from the list, so that we can keep track of how many are left on the map
            Enemies.Remove(enemyKilled);

            // Idea para luego respawnear
            OnEnemyKilled?.Invoke(enemyKilled.gameObject);
        }
    }
}
