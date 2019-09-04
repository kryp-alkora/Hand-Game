
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private GameObject actor;

    [SerializeField] private float moveSpeed = 3;

    private Vector3 mousePosition;
    private Vector3 LookDirection;
    // Start is called before the first frame update
    void Start()
    {
        //Find character to control
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Quaternion lookRotation = GetMouseInput();
        actor.transform.rotation = lookRotation;

        Vector3 moveDirection = GetInput();
        actor.transform.Translate(moveDirection *Time.deltaTime* moveSpeed, Space.World);


    }

    private Quaternion GetMouseInput()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width/2, mousePos.y - Screen.height/2);
        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        return rot;
    }

    private Vector3 GetInput()
    {
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        return input;
    }
}
