using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool onEarth;
    GameManager GM;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        GM = manager.GetComponent<GameManager>();
        onEarth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.Alive)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.z < 4.431161)
                {
                    this.transform.Translate(0f, 0f, 4.3f * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.z > -4.431161)
                {
                    this.transform.Translate(0f, 0f, -4.3f * Time.deltaTime);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && onEarth)
            {
                this.GetComponent<Rigidbody>().AddForce(0f, 300f, 0f);
            }
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (GM.Alive)
        {
            if (collision.gameObject.tag == "Palne")
            {
                onEarth = true;
            }
            else if (collision.gameObject.tag == "Barrier")
            {
                GM.Lose();
                Debug.Log("Hit!!!!");
            }
            else if (collision.gameObject.tag == "Coin")
            {
                GM.getCoin();
                Debug.Log("Coin!!!!");
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (GM.Alive)
        {
            if (collision.gameObject.tag == "Palne")
            {
                onEarth = false;
            }

        }
    }
}
