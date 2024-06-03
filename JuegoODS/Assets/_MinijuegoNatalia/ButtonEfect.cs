using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        //Variables
        [Header("Settings")]
        [SerializeField] private bool m_tweenScaleOnPress = true;
        [SerializeField] private bool m_tweenScaleOnHover = true;
        [SerializeField] private float m_multiplier = 1;

        private Coroutine m_tweenCoroutine;
        private Button m_button;

        private bool m_selected;

        //Constants
        private const float m_tweenHoverScale = 0.05f;
        private const float m_tweenPressScale = -0.1f;
        private const float m_tweenSelectScale = 0.1f;

        private const float m_tweenTime = 0.03f;

        //Methods
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            TryGetComponent(out m_button);
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            transform.localScale = Vector3.one;
            m_selected = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!m_tweenScaleOnHover) return;
            if (m_button && !m_button.IsInteractable()) return;
            if (m_selected) return;

            if (m_tweenCoroutine != null) StopCoroutine(m_tweenCoroutine);
            m_tweenCoroutine = StartCoroutine(TweenScale(m_tweenHoverScale));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!m_tweenScaleOnHover) return;
            if (m_button && !m_button.IsInteractable()) return;
            if (m_selected) return;

            if (m_tweenCoroutine != null) StopCoroutine(m_tweenCoroutine);
            m_tweenCoroutine = StartCoroutine(TweenScale(0));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!m_tweenScaleOnPress) return;
            if (m_button && !m_button.IsInteractable()) return;
            if (m_selected) return;

            if (m_tweenCoroutine != null) StopCoroutine(m_tweenCoroutine);
            m_tweenCoroutine = StartCoroutine(TweenScale(m_tweenPressScale));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!m_tweenScaleOnPress) return;
            if (m_button && !m_button.IsInteractable()) return;
            if (m_selected) return;

            if (m_tweenCoroutine != null) StopCoroutine(m_tweenCoroutine);
            m_tweenCoroutine = StartCoroutine(TweenScale(0));
        }

        public void OnSelect(bool select)
        {
            if (m_button && !m_button.IsInteractable()) return;
            m_selected = select;

            if (m_tweenCoroutine != null) StopCoroutine(m_tweenCoroutine);
            m_tweenCoroutine = StartCoroutine(TweenScale(select ? m_tweenSelectScale : 0));
        }

        //Coroutines
        private IEnumerator TweenScale(float scale)
        {
            float a = transform.localScale.x;
            float b = 1 + (scale * m_multiplier);

            for (float i = 0; i < m_tweenTime; i += Time.unscaledDeltaTime)
            {
                transform.localScale = Vector3.one * Mathf.Lerp(a, b, i / m_tweenTime);
                yield return null;
            }

            transform.localScale = Vector3.one * b; ;
        }
    }
}
