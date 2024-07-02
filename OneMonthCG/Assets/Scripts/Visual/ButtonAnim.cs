using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    [SerializeField] private GameObject _clickAudio;
    [SerializeField] private AudioClip _audio;
    private RectTransform _rect;

    public void AudioClick()
    {
        GameObject newAud = Instantiate(_clickAudio);
        newAud.GetComponent<AudioSource>().clip = _audio;
        newAud.GetComponent<AudioSource>().Play();
        Destroy(newAud,2f);
    }

    public void Enter()
    {
        _rect = GetComponent<RectTransform>();
        _rect.localScale = new Vector2(1.15f,1.15f);
    }

    public void Exit()
    {
        _rect = GetComponent<RectTransform>();
        _rect.localScale = Vector2.one;
    }
}
