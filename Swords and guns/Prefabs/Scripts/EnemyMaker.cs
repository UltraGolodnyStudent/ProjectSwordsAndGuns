using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    private GameObject _enemy;
    public void Initialized(GameObject enemy)
    {
        _enemy = enemy;
    }

    private void CreateAnEnemy()
    {
        // сперва создать потом все проинициализировать
    }
}
