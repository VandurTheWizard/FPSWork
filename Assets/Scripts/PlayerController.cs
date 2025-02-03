using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float sensiblidadCamara = 2f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputAction.CallbackContext context){
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 movimiento = new Vector3(input.x, 0, input.y) * velocidad * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movimiento));
    }
}
