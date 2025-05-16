using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector2 Movement { get; private set; }

    private void Update()
    {
        float xAxis = Input.GetAxisRaw(Horizontal);
        float yAxis = Input.GetAxisRaw(Vertical);

        Movement = new Vector2(xAxis, yAxis).normalized;
    }
}
