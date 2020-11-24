using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject textObject;
    public GameObject timerObject;

    [SerializeField] private GameObject foodPrefab;

    public float activeLength = 5f;

    private float minX = -9f;
    private float maxX = 9f;
    private float x;

    private float y = 14f;

    private float minZ = -6.6f;
    private float maxZ = 10.5f;
    private float z;

    private float initialDelay = 1.5f;
    private float minSpawnTime = .3f;
    private float maxSpawnTime = 1f;
    private float currentSpawnTime;

    private bool delaying = true;
    private bool coolingDown = false;
    private bool end = false;

    private TextChanger timer;

    private void Start()
    {
        timer = timerObject.GetComponent<TextChanger>();
        timer.ChangeText(activeLength.ToString() + ".00");
        StartCoroutine(StartInitialDelay());
    }

    private void Update()
    {
        if (!delaying)
        {

            if (!coolingDown && !end)
            {
                StartCoroutine(SpawnCooldown());
            }

            if (activeLength <= 0)
            {
                end = true;
                timer.ChangeText("0.00");
                StartCoroutine(End());
            }

            else
            {
                activeLength -= Time.deltaTime;
                string strLen = activeLength.ToString("#0.00");
                timer.ChangeText(strLen);
            }
        }
    }

    private IEnumerator End()
    {
        TextChanger textChanger = textObject.GetComponent<TextChanger>();
        textChanger.ChangeText("Time!");
        yield return new WaitForSeconds(4f);
        SceneChanger s = GetComponent<SceneChanger>();
        s.ChangeScene();
    }

    private IEnumerator StartInitialDelay()
    {
        TextChanger textChanger = textObject.GetComponent<TextChanger>();
        textChanger.ChangeText("Ready?");
        delaying = true;
        yield return new WaitForSeconds(initialDelay);
        textChanger.ChangeText("GO!");
        yield return new WaitForSeconds(.5f);
        textChanger.ChangeText("");
        delaying = false;
    }

    private IEnumerator SpawnCooldown()
    {
        coolingDown = true;

        x = Random.Range(minX, maxX);
        z = Random.Range(minZ, maxZ);

        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        yield return new WaitForSeconds(currentSpawnTime);
        SpawnFood();

        coolingDown = false;
    }

    private void SpawnFood()
    {
        Vector3 spawnCoordinates = new Vector3(x, y, z);

        Instantiate(foodPrefab, spawnCoordinates, Quaternion.identity);
    }
}
