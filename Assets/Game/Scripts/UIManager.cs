using TMPro;

using UnityEngine;

public class UIMainManager : MonoBehaviour
{
    public static UIMainManager instance;

    [SerializeField]
    private GameObject gameStateText;
    [SerializeField]
    private TMP_Text distanceText;
    [field: SerializeField] private GameObject Menu { get; set; }

    private bool isForwardWheelInAir;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        ScoreTracker.instance.OnReachNewDistanceEvent.AddListener(UpdateReachedDistanceText);
        Menu.SetActive(false);
    }

    public void SetWheelState(Wheel type, bool isInAir)
    {
        switch (type)
        {
            case Wheel.Forward:
                isForwardWheelInAir = isInAir;
                break;
        }

        UpdateTextState();
    }
    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    private void UpdateTextState()
    {
        if (gameStateText == null) return;

        if (isForwardWheelInAir)
            gameStateText.SetActive(true);
        else
            gameStateText.SetActive(false);
    }

    private void UpdateReachedDistanceText(float distance)
    {
        distanceText.text = Mathf.RoundToInt(distance).ToString();
    }
}
