using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public List<GameObject> fruits;
    static public string fruitState = "inAir";
    static public Vector2 mousePos;

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
            fruitState = "inAir";
        }
    }
    public void SpawnFruit()
    {
        Instantiate(fruits[Random.Range(0, fruits.Count)],new Vector2(0, 3), Quaternion.identity);
    }

}
