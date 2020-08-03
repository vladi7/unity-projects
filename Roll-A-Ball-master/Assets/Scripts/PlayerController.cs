using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector3 lastVelocity = Vector3.zero;
    public float speed;
    private Rigidbody rb;
    public Text countText;
    private int count;
    public Text winText;
    private int winCount;

    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.text = "";
        winCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        lastVelocity = rb.velocity;
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= winCount) {
            winText.text = "You Win";
        }
    }
}
