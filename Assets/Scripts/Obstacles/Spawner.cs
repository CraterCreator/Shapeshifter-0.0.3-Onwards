﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject[] Spikes;
    public GameObject line, holder, lastScore, highScore, curSpike;
    public GameObject ob1, ob2, ob3, ob4, ob5;
    public List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3 });
    public float spawnTime;
    public int counter;
    public Collision col;
    public UI ui;

    private GameObject spike;
    private int index, zero, one, two, three;
    private float scoreX;
    private bool num0, num1, num2, num3;

    void OnEnable()
    {
        spawnTime = 1.5f;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < i + 1; i++)
        {
            index = numbers[Random.Range(Mathf.Min(numbers.ToArray()), numbers.Count)];
            spike = Spikes[index];
            if (spawnTime > 0.9)
            {
                spawnTime -= 0.01f;
                if (Time.timeScale < 1.51)
                {
                    Time.timeScale += 0.01f;
                }
            }
            counter += 1;
            if (col.gameover == false)
            {
                curSpike = Instantiate(spike, spawnPos.position, spawnPos.rotation);
            }

            if (counter == ui.highScore && ui.highScore > 0)
            {
                if (spike == Spikes[0])
                {
                    scoreX = -1.7f;
                }

                if (spike == Spikes[1] || Spikes[2])
                {
                    scoreX = 1.7f;
                }

                if (spike == Spikes[2])
                {
                    scoreX = 0;
                }
                SpawnHighScoreHolder();
            }

            if (counter == col.lastScore && col.lastScore > 0)
            {
                if (spike == Spikes[0])
                {
                    scoreX = 1.7f;
                }

                if (spike == Spikes[1] || Spikes[2])
                {
                    scoreX = -1.7f;
                }

                if (spike == Spikes[3])
                {
                    scoreX = 0;
                }
                SpawnPreviousScoreHolder();
            }
            switch (counter)
            {
                case 20:
                    ChallengeSpawnConstants(1);
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob1, spawnPos.position, spawnPos.rotation);
                    yield return new WaitForSeconds(4);
                    break;
                case 40:
                    ChallengeSpawnConstants(2);
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob2, spawnPos.position, spawnPos.rotation);
                    yield return new WaitForSeconds(4);
                    break;
                case 60:
                    ChallengeSpawnConstants(3);
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob3, spawnPos.position, spawnPos.rotation);
                    yield return new WaitForSeconds(5);
                    break;
                case 80:
                    ChallengeSpawnConstants(4);
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob4, spawnPos.position, spawnPos.rotation);
                    yield return new WaitForSeconds(6);
                    break;
                case 100:
                    ChallengeSpawnConstants(5);
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob5, spawnPos.position, spawnPos.rotation);
                    yield return new WaitForSeconds(6);
                    break;
            }

            #region 0
            if (index == 0)
            {
                zero++;
            }
            else
            {
                zero = 0;
            }

            if (zero >= 2)
            {
                numbers.RemoveRange(0, 1);
                num0 = true;
            }

            if (zero == 0 && num0 == true)
            {
                numbers.Insert(0, 0);
                num0 = false;
            }
            #endregion

            #region 1
            if (index == 1)
            {
                one++;
            }
            else
            {
                one = 0;
            }

            if (one >= 2)
            {
                numbers.RemoveRange(1, 1);
                num1 = true;
            }

            if (one == 0 && num1 == true)
            {
                numbers.Insert(1, 1);
                num1 = false;
            }
            #endregion

            #region 2
            if (index == 2)
            {
                two++;
            }
            else
            {
                two = 0;
            }

            if (two >= 2)
            {
                numbers.RemoveRange(2, 1);
                num2 = true;
            }

            if (two == 0 && num2 == true)
            {
                numbers.Insert(2, 2);
                num2 = false;
            }
            #endregion

            #region 3
            if (index == 3)
            {
                three++;
            }
            else
            {
                three = 0;
            }

            if (three >= 2)
            {
                numbers.RemoveRange(3, 1);
                num3 = true;
            }

            if (three == 0 && num3 == true)
            {
                numbers.Insert(3, 3);
                num3 = false;
            }
            #endregion

            yield return new WaitForSeconds(spawnTime);
        }
    }

    void ChallengeSpawnConstants(int number)
    {
        GameObject curLine = Instantiate(line, curSpike.transform.position, Quaternion.Euler(0, 0, 0));
        curLine.GetComponent<Animator>().SetFloat("Number", number);
        curLine.transform.parent = curSpike.transform;
    }

    void SpawnPreviousScoreHolder()
    {
        GameObject curHolder = Instantiate(holder, curSpike.transform.position, Quaternion.Euler(0, 0, 0));
        GameObject curText = Instantiate(lastScore, new Vector3(spawnPos.position.x + scoreX, spawnPos.position.y - 0.4f, 1), Quaternion.Euler(0, 0, 0));
        curHolder.transform.parent = curSpike.transform;
        curText.transform.parent = curHolder.transform;
    }
    
    void SpawnHighScoreHolder()
    {
        GameObject curHolder = Instantiate(holder, curSpike.transform.position, Quaternion.Euler(0, 0, 0));
        GameObject curText = Instantiate(highScore, new Vector3(spawnPos.position.x + scoreX, spawnPos.position.y - 0.4f, 1), Quaternion.Euler(0, 0, 0));
        curHolder.transform.parent = curSpike.transform;
        curText.transform.parent = curHolder.transform;
    }
}
