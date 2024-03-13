using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public List<GameObject> spawnerFruits;
    public List<GameObject> fruits;
    static public string fruitState = "inAir";
    static public Vector2 mousePos;
    static public float spawningHeight = 8f;
    static public Vector2 mergePos;
    static public int mergeTier;

    private void Start()
    {
        SpawnFruit();
    }

    public void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (fruitState == "inAir")
            {
                Fruit.fruitFall(mousePos);
            }
        }
        if (fruitState == "landed")
        {
            SpawnFruit();
        }
        if (fruitState == "merging")
        {
            MergeFruits(mergeTier, mergePos);
        }
        print(fruitState);
    }
    public void SpawnFruit()
    {
        Instantiate(spawnerFruits[Random.Range(0, spawnerFruits.Count)], new Vector2(0, spawningHeight), Quaternion.identity);
        fruitState = "inAir";
    }
    void MergeFruits(int tier, Vector2 pos)
    {
        if (tier <= fruits.Count)
        {
            var fruit = Instantiate(fruits[tier + 1], pos, Quaternion.identity);
            var fruitRb = fruit.GetComponent<Rigidbody2D>();
            fruit.GetComponent<Fruit>().fruitLanded = true;
            fruitRb.gravityScale = 2;
            SpawnFruit();
        }
    }
}

