using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   [SerializeField] private GameObject _menuButton;
   [SerializeField] private GameObject _menuWindow;

   [SerializeField] private MonoBehaviour[] _objectsToDisable; 

   public void OpenMenu()
   {
      _menuButton.SetActive(false);
      _menuWindow.SetActive(true);

      Time.timeScale = 0.001f;

      for (int i = 0; i < _objectsToDisable.Length; i++)
      {
         _objectsToDisable[i].enabled = false;
      }
   }

   public void CloseMenu()
   {
      _menuButton.SetActive(true);
      _menuWindow.SetActive(false);

      Time.timeScale = 1f;

      for (int i = 0; i < _objectsToDisable.Length; i++)
      {
         _objectsToDisable[i].enabled = true;
      }
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Time.timeScale = 1f;
   }
}
