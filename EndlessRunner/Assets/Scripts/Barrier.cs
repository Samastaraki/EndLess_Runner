using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    GameManager GM;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
        GM = manager.GetComponent<GameManager>();
        Destroy(this.gameObject, 40);
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.Alive)
        {
            this.transform.Translate(5f * Time.deltaTime, 0f, 0f);
        }
    }
}
