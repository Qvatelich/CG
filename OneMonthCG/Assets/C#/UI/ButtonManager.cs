using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject _deck;

    public void StartFreeGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndFreeGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenDeck()
    {
        _deck.SetActive(true);
    }

    public void CloseDeck()
    {
        _deck.SetActive(false);
    }
}
