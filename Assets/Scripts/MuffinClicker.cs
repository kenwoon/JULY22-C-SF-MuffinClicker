using UnityEngine;
using TMPro;

public class MuffinClicker : MonoBehaviour
{ 
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI _textRewardPrefab;

    [SerializeField]
    private float _xmin, _xmax, _ymin, _ymax;

    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();

        CreateTextRewardPrefab(addedMuffins);
    }

    private void CreateTextRewardPrefab(int addedMuffins)
    {
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
        Vector2 randomVector = MyToolbox.GetRandomVector2(_xmin, _xmax, _ymin, _ymax);
        textRewardClone.transform.localPosition = randomVector;
        textRewardClone.text = $"+{addedMuffins}";
    }
}
