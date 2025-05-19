using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private KeyCode _openKey = KeyCode.E;

    public Vector2 Movement { get; private set; }
    public bool IsOpenKeyPressed => Input.GetKeyDown(_openKey);

    private void Update()
    {
        float xAxis = Input.GetAxisRaw(Horizontal);
        float yAxis = Input.GetAxisRaw(Vertical);

        Movement = new Vector2(xAxis, yAxis).normalized;
    }
}
