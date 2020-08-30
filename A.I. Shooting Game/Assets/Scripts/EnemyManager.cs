using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemies;
    public ShootingAgent agent;

    private int EnemyCount;
    private EnvironmentParameters EnvironmentParameters;
    private int startingPoint = 0;
    public int score;
        public Text scoreText;
    public int score_time=0;
    private int score_count=0;
private int score_count2=0,rest=0;

    private void Start()
    {
        EnvironmentParameters = Academy.Instance.EnvironmentParameters;
        EnemyCount = Mathf.FloorToInt(EnvironmentParameters.GetWithDefault("amountZombies", 4f));
        
        SetEnemiesActive();
        score=0;
        score_time=0;
    }

    public void Update()
    {
        //matematica asta este aici ca sa imi demonstreze
        //ca este inca vara
        score_time++;
        if(score_time>60){
            score_count=score_time/60;
            if(score_count>60) {
                score_count2=score_count/60;
                rest=score_count%60;
                 scoreText.text=score_count2.ToString()+" m "+rest+" s";
            }else{
                scoreText.text=score_count.ToString()+" s";
            }
        }else {
            scoreText.text=score_time.ToString()+" ms";
        }
       
    }

    public bool isEveryEnemyDead()
    {
        int deathCounter = 0;
        
        for (int i = startingPoint; i < EnemyCount + startingPoint; i++)
        {
            if (!enemies[i].isActiveAndEnabled) {
                deathCounter++;
                score++; }
        }

        return deathCounter >= EnemyCount;
    }

    public void RegisterDeath()
    {
        if (isEveryEnemyDead())
        {
            SetEnemiesActive();
            agent.EndEpisode();
        }
    }

    public void SetEnemiesActive()
    {
        int counter = 0;
        EnemyCount = Mathf.FloorToInt(EnvironmentParameters.GetWithDefault("amountZombies", 4f));

        startingPoint = Mathf.FloorToInt(Random.Range(0f, enemies.Length - EnemyCount));

        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
        
        for (int i = startingPoint; i < EnemyCount + startingPoint; i++)
        {
            counter++;
            enemies[i].gameObject.SetActive(true);
        }
    }
}
