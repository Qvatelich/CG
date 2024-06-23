using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Enter()
    {
        rect.localScale = new Vector2(1.2f,1.2f);
    }

    public void Exit()
    {
        rect.localScale = Vector2.one;
    }
}
