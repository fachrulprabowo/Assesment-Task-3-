using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myBody;
    public bool isGun;
    public GameObject gun;
    public bool isGrounded;
    public float speed;
    public GameObject bullet;
    public Transform pointGun;
    public int side;
    public GameObject lose;
    public GameObject win;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    public void MoveThePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            side = -1;
            myBody.transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            side = 1;
            myBody.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 11);
        }

        if (Input.GetKeyDown(KeyCode.Z) && isGun)
        {
            Shoot();
        }
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 18, Camera.main.transform.position.y, -10);
        }
        if (collision.gameObject.tag == "RightCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 18, Camera.main.transform.position.y, -10);
        }
        if (collision.gameObject.tag == "UpCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 10, -10);
        }
        if (collision.gameObject.tag == "DownCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-10, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LeftCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 18, Camera.main.transform.position.y, -10);
        }
        if (collision.gameObject.tag == "RightCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 18, Camera.main.transform.position.y, -10);
        }
        if (collision.gameObject.tag == "UpCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 10, -10);
        }
        if (collision.gameObject.tag == "DownCamera")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 10, -10);
        }


        if (collision.gameObject.tag == "Death")
        {
            GameOver();
        }

        if (collision.gameObject.tag == "Win")
        {
            Win();
        }

        if (collision.gameObject.tag == "Gun")
        {
            isGun = true;
            gun.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameOver();
        }
    }

    public void Shoot()
    {
        GameObject shootBullet = Instantiate(bullet, pointGun.position, Quaternion.identity);
        Bullet scriptBullet = shootBullet.GetComponent<Bullet>();
        scriptBullet.side = side;
        scriptBullet.Launch();

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        lose.gameObject.SetActive(true);
    }
    public void Win()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        win.SetActive(true);
    }
    public void _OnButtonRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
