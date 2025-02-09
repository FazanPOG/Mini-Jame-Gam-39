using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Image _cursorImage;
        [SerializeField] private GameObject _reloadGameView;

        public void ShowCursor() => _cursorImage.gameObject.SetActive(true);
        public void HideCursor() => _cursorImage.gameObject.SetActive(false);

        public void ShowReloadGameView() => _reloadGameView.SetActive(true);
    }
}