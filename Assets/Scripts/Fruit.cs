using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    static public Rigidbody2D rb;
    public bool fruitLanded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    static public void fruitFall(Vector2 mousePosition)
    {    
        if (FruitSpawner.fruitState == "inAir")
        {
            rb.gravityScale = 2;
            rb.position = new Vector2(mousePosition.x, 3);
            FruitSpawner.fruitState = "falling";
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!fruitLanded && collision.gameObject.tag != "sideBorder") 
        {
            fruitLanded = true;
            FruitSpawner.fruitState = "landed";
            print("collision");
        }    
    }
}
