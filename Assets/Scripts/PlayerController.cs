using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Speed of the ball - public variables can be modified from Unity window
    public float ballSpeed;
    // Text on the Screen, which display the number of points
    public Text countText;
    // Text on the Screen, which will be displayed when Player collects all the points
    public Text winText;

    // Rigidbody connected with this GameObject
    private Rigidbody rb;
    // Number of points which PLayer score
    private int countPoints = 0;

    // Use this for initialization
    void Start()
    {
        // Get Rigidbody Component from THIS GameObject
        rb = GetComponent<Rigidbody>();
        // Initialize the text on the Screen
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
	}

    // FixedUpdate is called before any physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // X-Axis
        float moveVertical = Input.GetAxis("Vertical"); // Z-Axis

        // Adding movement as force to object
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * ballSpeed);
    }

    // When Player collide with Pick Up object
    void OnTriggerEnter(Collider other)
    {
        // If collided object has tag "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // Make the collided GameObject inactive
            other.gameObject.SetActive(false);
            // Add point after collision
            countPoints++;
            // Update Text value on the Screen
            SetCountText();
        }
    }

    // For not writing the same code twice
    void SetCountText()
    {
        countText.text = "Count: " + countPoints.ToString();
        if (countPoints >= 15)
            winText.text = "You Win !!!";
    }
}