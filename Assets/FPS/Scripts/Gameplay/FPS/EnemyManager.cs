/*    
  Copyright (C) 2026 Narratech Laboratories
  https://www.narratech.com
  Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
  Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).
  Autor: Federico Peinado 
  Contacto: email@federicopeinado.com
*/

using System;
using UnityEngine;
using Unity.FPS.AI;

public static class EnemyManager
{
    public static Action<GameObject> OnEnemyKilled;

    public static void UnregisterEnemy(EnemyController enemy)
    {
        OnEnemyKilled?.Invoke(enemy.gameObject);
    }
}