using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the Player GameObject
    public GameObject player;
    // Difference between Camera position and Player position
    private Vector3 offset;

	// Use this for initialization
	void Start()
    {
        // Difference between Camera position and Player position
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called after every item was process in Update
	void LateUpdate()
    {
        // Each frame set Camera position to Player poistion + Offset
        transform.position = player.transform.position + offset;
	}
}