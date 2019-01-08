using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject[] Spikes;
    public GameObject line;
    public GameObject ob1, ob2, ob3, ob4, ob5;
    public List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3 });
    public float spawnTime;
    public int counter;
    public int destroyTimer;

    private int index, zero, one, two, three;
    private GameObject spike, menu;
    private bool off, num0, num1, num2, num3;


    // Use this for initialization
    void Start()
    {
        off = true;
        spawnTime = 1.5f;
        destroyTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (off == true)
        {
            StartCoroutine(Spawn());
            off = false;
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < i + 1; i++)
        {
            if (spawnTime > 0.9)
            {
                spawnTime -= 0.01f;
            }
            counter += 1;
            index = numbers[Random.Range(Mathf.Min(numbers.ToArray()), numbers.Count)];
            spike = Spikes[index];
            Instantiate(spike, spawnPos.position, spawnPos.rotation);

            switch (counter)
            {
                case 20:
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob1, spawnPos.position, spawnPos.rotation);
                    destroyTimer = 5;
                    yield return new WaitForSeconds(3);
                    break;
                case 40:
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob2, spawnPos.position, spawnPos.rotation);
                    destroyTimer = 6;
                    yield return new WaitForSeconds(4);
                    break;
                case 60:
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob3, spawnPos.position, spawnPos.rotation);
                    destroyTimer = 7;
                    yield return new WaitForSeconds(4);
                    break;
                case 80:
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob4, spawnPos.position, spawnPos.rotation);
                    destroyTimer = 8;
                    yield return new WaitForSeconds(5);
                    break;
                case 100:
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    yield return new WaitForSeconds(spawnTime);
                    Instantiate(ob5, spawnPos.position, spawnPos.rotation);
                    destroyTimer = 9;
                    yield return new WaitForSeconds(5);
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

    void OnEnable()
    {
        spawnTime = 1.5f;
        off = true;
    }
}
