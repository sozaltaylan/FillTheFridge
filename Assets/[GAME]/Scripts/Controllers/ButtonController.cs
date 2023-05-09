using ColorAndFill.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(HandleOnButtonClicked);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleOnButtonClicked);
    }

    private void HandleOnButtonClicked()
    {
        BoxManager.Instance.CloseOpenedBox();
        UIManager.Instance.CloseOkButton();
    }
}
