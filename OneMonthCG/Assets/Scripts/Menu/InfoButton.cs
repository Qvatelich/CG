using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

   public void CheckInfo()
   {
        GameObject[] activePanels = GameObject.FindGameObjectsWithTag("ActivePanel");
        foreach (GameObject panel in activePanels)
        {
            panel.SetActive(false);
        }
        _infoPanel.SetActive(true);
   }
}
