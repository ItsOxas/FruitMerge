using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    static public Rigidbody2D rb;
    public bool fruitLanded;
    public int fruitTier;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (gameObject.transform.position.y > FruitSpawner.spawningHeight)
        {
            Destroy(gameObject);
        }
    }
    static public void fruitFall(Vector2 mousePosition)
    {    
        if (FruitSpawner.fruitState == "inAir")
        {
            rb.gravityScale = 2;
            rb.position = new Vector2(mousePosition.x, FruitSpawner.spawningHeight);
            FruitSpawner.fruitState = "falling";
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.transform.position.y < FruitSpawner.spawningHeight)
        {

            if (!fruitLanded && collision.gameObject.tag != "sideBorder")
            {
                fruitLanded = true;
                FruitSpawner.fruitState = "landed";
            }
                if (collision.gameObject.tag == "Fruit")
                {
                var otherFruit = collision.gameObject.GetComponent<Fruit>();
                int otherFruitTier = otherFruit.fruitTier;
                    if (otherFruitTier == fruitTier)
                    {
                        FruitSpawner.fruitState = "merging";
                        FruitSpawner.mergeTier = fruitTier;
                        FruitSpawner.mergePos = gameObject.transform.position;
                        Destroy(gameObject);
                        Destroy(collision.gameObject);
                }
                }
        }    
    }
}
