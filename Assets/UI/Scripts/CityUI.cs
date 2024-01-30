using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Goodini
{
    public class CityUI : Service
    {
        [SerializeField]
        private Joystick _joyStick;

        public Joystick JoyStick => _joyStick;

        [SerializeField]
        private RectTransform _buttonsParent;

        [SerializeField]
        private Button _resetBTN;

        public Button ResetBTN => _resetBTN;

        [SerializeField]
        private TouchPad _touchPad;

        public TouchPad TouchPad => _touchPad;

        private const float START_Y_POSITION = 400f;

        private City _city;

        private void Awake()
        {
            CitySpawnerServiceLocator.LocatorInited += OnLocatorInited;
        }

        private void OnLocatorInited(IServiceLocator<Service> locator)
        {
            _locator = locator;
            _city = locator.Get<City>();
            for ( int i = 0; i < _city.Buildings.Length; i++ )
            {
                if ( _city.Buildings[i] )
                {
                    CreateButton(START_Y_POSITION - i * 50, _city.Buildings[i], $"Здание {( i + 1 )}", $"Building{( i + 1 )}");
                }
            }
        }

        private void CreateButton(float positionY, Transform buildingTransform, string btnText, string buttonName = "Button")
        {
            GameObject btn = new(buttonName);
            btn.transform.SetParent(_buttonsParent);
            Button button = btn.AddComponent<Button>();
            ControlBtn btnControl = btn.AddComponent<ControlBtn>();
            Image image = btn.AddComponent<Image>();

            if ( !btn.TryGetComponent(out RectTransform rectTransform) )
            {
                rectTransform = btn.AddComponent<RectTransform>();
            }

            SetDefaultRectConfig(rectTransform, positionY);

            SetDefaultButtonStyle(button,image);

            GameObject textGo = new("Text");
            textGo.transform.SetParent(btn.transform);
            TextMeshProUGUI text = textGo.AddComponent<TextMeshProUGUI>();
            
            SetDefaultTextConfig(text, btnText, btn.transform);
            
            btn.transform.localScale = Vector3.one;

            button.onClick.AddListener(() => btnControl.ChooseBuilding(buildingTransform));
        }

        private void SetDefaultTextConfig(TextMeshProUGUI textComponent, string text, Transform parent)
        {
            textComponent.transform.SetParent(parent);
            textComponent.color = Color.black;
            textComponent.fontSize = 24;
            textComponent.text = text;
            textComponent.alignment = TextAlignmentOptions.Center;
            textComponent.alignment = TextAlignmentOptions.Midline;
            textComponent.rectTransform.anchorMin = new Vector2(0f, 0f);
            textComponent.rectTransform.anchorMax = new Vector2(1f, 1f);
            textComponent.rectTransform.pivot = new Vector2(.5f, .5f);
        }
        
        private void SetDefaultButtonStyle(Button button, Image image)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.pressedColor = Color.gray;
            button.colors = colorBlock;
            button.targetGraphic = image;
        }

        private void SetDefaultRectConfig(RectTransform rectTransform, float position)
        {
            rectTransform.localPosition = new Vector3(0f, position, 0f);
            rectTransform.sizeDelta = new Vector2(300f, 45f);
            rectTransform.anchorMin = new Vector2(.5f, 0);
            rectTransform.anchorMax = new Vector2(.5f, 0);
        }
    }
}