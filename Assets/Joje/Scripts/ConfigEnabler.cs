using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Joje.Scripts
{
    public class ConfigEnabler : MonoBehaviour
    {
        [SerializeField] private Button enablerButton;
        [SerializeField] private RectTransform configIconRect;
        [SerializeField] private RectTransform configPanelRect;
        [SerializeField] private float tweeningTime;
        [SerializeField] private float iconRotationMultiplier;

        private bool isConfigEnabled = false;
        private Sequence tweeningSequence;

        private void Awake()
        {
            isConfigEnabled = false;
            configPanelRect.anchoredPosition = TargetRetractedPanelPosition;
            enablerButton.onClick.AddListener(Toggle);
        }

        private Vector2 TargetRetractedPanelPosition
        {
            get
            {
                var value = configPanelRect.anchoredPosition;
                value.x = -configPanelRect.rect.width;
                return value;
            }
        }

        private void Toggle()
        {
            if (isConfigEnabled)
            {
                Hide();
            }
            else
            {
                Show();
            }

            isConfigEnabled = !isConfigEnabled;
        }

        private void Show()
        {
            tweeningSequence.Kill();
            tweeningSequence = DOTween.Sequence();
            var targetRotation = new Vector3(0, 0, 360 * iconRotationMultiplier);
            tweeningSequence.Join(configIconRect.DORotate(targetRotation, tweeningTime, RotateMode.LocalAxisAdd));
            tweeningSequence.Join(configPanelRect.DOAnchorPos(Vector2.zero, tweeningTime));
            tweeningSequence.Play();
        }

        private void Hide()
        {
            tweeningSequence.Kill();
            tweeningSequence = DOTween.Sequence();
            var targetRotation = new Vector3(0, 0, -360 * iconRotationMultiplier);
            tweeningSequence.Join(configIconRect.DORotate(targetRotation, tweeningTime, RotateMode.LocalAxisAdd));
            tweeningSequence.Join(configPanelRect.DOAnchorPos(TargetRetractedPanelPosition, tweeningTime));
            tweeningSequence.Play();
        }
    }
}