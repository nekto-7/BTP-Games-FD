using UnityEngine;
using Mirror;
public class FirstPersonLook : NetworkBehaviour
{

    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;

    public float rotationSpeed = 5;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y")); // Invert the Y axis
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }


    void LateUpdate()
    {
        transform.position = character.position + Vector3.up * 1.5f; // 1.5f - это примерное расстояние от головы до камеры
        transform.rotation = character.rotation;

        // Rotate only the camera, not the character.
        transform.Rotate(Vector3.right, velocity.y);
        character.Rotate(Vector3.up, velocity.x);

        // Reset frameVelocity to prevent sudden camera movements when the character moves.
        frameVelocity = Vector2.zero;
    }
}