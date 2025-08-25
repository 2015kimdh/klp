using System.Collections;
using UnityEngine;

namespace Script.Presentation.UI
{
    public class RewardParticleEffect : MonoBehaviour
    {
        #region Serialize Field

        [Header("이펙트 출력 딜레이")] [SerializeField]
        private float normalEffectDelay;

        [SerializeField] private float epicEffectDelay;

        [Space(10)] [SerializeField] private ParticleSystem normalEffect;
        [SerializeField] private ParticleSystem epicEffect;

        [Header("레어도 색상")] [SerializeField] private Color commonColor = Color.white;
        [SerializeField] private Color epicColor;
        [SerializeField] private Color legendaryColor;
        [SerializeField] private Color supremeColor;

        [Header("Presenter")] [SerializeField] private GetGachaResultPresenter presenter;

        #endregion

        #region Methods

        public void OnSceneEnter()
        {
            StartCoroutine(StartNormal());
            if (presenter.rewardItem.rarity < 2)
            {
                var main = normalEffect.main;
                main.startColor = commonColor;
            }
            else
            {
                var main = normalEffect.main;
                var epicMain = epicEffect.main;
                switch (presenter.rewardItem.rarity)
                {
                    case 2:
                        main.startColor = epicColor;
                        epicMain.startColor = epicColor;
                        break;
                    case 3:
                        main.startColor = legendaryColor;
                        epicMain.startColor = legendaryColor;
                        break;
                    case 4:
                        main.startColor = supremeColor;
                        epicMain.startColor = supremeColor;
                        break;
                }

                StartCoroutine(StartEpic());
            }

            normalEffect.Clear();
            epicEffect.Clear();
            normalEffect.gameObject.SetActive(false);
            epicEffect.gameObject.SetActive(false);
        }

        public void OnSceneExit()
        {
            normalEffect.Clear();
            epicEffect.Clear();
            normalEffect.gameObject.SetActive(false);
            epicEffect.gameObject.SetActive(false);
        }
        
        public IEnumerator StartNormal()
        {
            yield return new WaitForSeconds(normalEffectDelay);
            normalEffect.gameObject.SetActive(true);
            normalEffect.Play();
        }

        public IEnumerator StartEpic()
        {
            yield return new WaitForSeconds(epicEffectDelay);
            epicEffect.gameObject.SetActive(true);
            epicEffect.Play();
        }

        #endregion
    }
}