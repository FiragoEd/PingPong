using Gameplay.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameFinishPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameWinnerText;
        [SerializeField] private Button _button;

        public Button RestartButton => _button;

        public void SetWinner(PlayerType playerType)
        {
            switch (playerType)
            {
                case PlayerType.Second:
                    _gameWinnerText.text = "Fist Player Win!";
                    break;
                case PlayerType.First:
                    _gameWinnerText.text = "Second Player Win!";
                    break;
                default:
                    _gameWinnerText.text = "Draw!";
                    break;
            }
        }
    }
}