using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public class StartWindow : MonoBehaviour {
		public Image	GoalBar = null;
		public TMP_Text GoalText = null;
		public Button	StartButton = null;
		public Button	CloseButton = null;

		bool _isInit = false;

		void Init() {
			var gc = GameplayController.Instance;

			StartButton.onClick.AddListener(StartGame);
			CloseButton.onClick.AddListener(gc.CloseGame);
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
				Time.timeScale = 0f;
				_isInit = true;
			}

			var gc = GameplayController.Instance;

			GoalBar.fillAmount = Mathf.Clamp01((float)gc.TotalOrdersServed / gc.OrdersTarget);
			GoalText.text = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";

			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}

		void StartGame() {
			Hide();
			Time.timeScale = 1f;
		}
	}
}