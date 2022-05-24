using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myBody;
    public float speed;
    public int side;
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death" || collision.tag == "Computer")
        {
            Destroy(collision.gameObject);
        }
    }

    public void Launch()
    {
        myBody.velocity = new Vector2(speed * side, 0);
    }
}
