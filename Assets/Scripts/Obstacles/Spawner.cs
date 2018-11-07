using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject[] Spikes;
    public GameObject menu, line;
    List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3 });

    private bool off, zero, one, two, three;
    private GameObject spike;
    private int index, lastNum;
    public int counter;

    public float spawnTime;

    // Use this for initialization
    void Start()
    {
        lastNum = -1;
        off = true;
        spawnTime = 1.5f;
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
            counter ++;
            index = numbers[Random.Range(Mathf.Min(numbers.ToArray()), numbers.Count)];
            spike = Spikes[index];
            Instantiate(spike, spawnPos.position, spawnPos.rotation);

            switch(counter)
            {
                case 10:
                    print("works");
                    Instantiate(line, new Vector3(spawnPos.position.x + 5, spawnPos.position.y, 1), Quaternion.Euler(0, -90, 0));
                    break;
            }

            if (zero == true)
            {
                numbers.Remove(0);
                lastNum = 0;
                zero = false;
            }

            if (one == true)
            {
                numbers.Remove(1);
                lastNum = 1;
                one = false;
            }

            if (two == true)
            {
                numbers.Remove(2);
                lastNum = 2;
                two = false;
            }

            if (three == true)
            {
                numbers.Remove(3);
                lastNum = 3;
                three = false;
            }

            switch (index)
            {
                case 0:
                    zero = true;
                    one = false;
                    two = false;
                    three = false;
                    if (lastNum != -1)
                    {
                        numbers.Add(lastNum);
                        lastNum = -1;
                    }
                    break;
                case 1:
                    one = true;
                    zero = false;
                    two = false;
                    three = false;
                    if (lastNum != -1)
                    {
                        numbers.Add(lastNum);
                        lastNum = -1;
                    }
                    break;
                case 2:
                    two = true;
                    zero = false;
                    one = false;
                    three = false;
                    if (lastNum != -1)
                    {
                        numbers.Add(lastNum);
                        lastNum = -1;
                    }
                    break;
                case 3:
                    three = true;
                    zero = false;
                    one = false;
                    two = false;
                    if (lastNum != -1)
                    {
                        numbers.Add(lastNum);
                        lastNum = -1;
                    }
                    break;
            }


            yield return new WaitForSeconds(spawnTime);
        }
    }

    void OnEnable()
    {
        off = true;
    }
}
