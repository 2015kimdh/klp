using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace Script.Presentation.UI
{
    [Serializable]
    public class UIAnimationController : MonoBehaviour
    {
        [SerializeField] private PlayableDirector director;

        [SerializeField] private Animator animator;
        [SerializeField] private float animationSpeed = 1f;
        [SerializeField] private bool useAnimationFinishEvent;

        public UnityEvent onAnimationFinish;

        private void Start()
        {
            animator.speed = animationSpeed;
            if (useAnimationFinishEvent)
            {
                director.stopped += OnAnimationFinish;
            }
        }

        public void StopAnimation()
        {
            director.time = 0;
            director.Stop();
        }

        public void StartAnimation()
        {
            director.time = 0;
            director.Play();
        }

        public void ResetAnimationStats()
        {
            director.time = 0;
        }
        
        private void OnAnimationFinish(PlayableDirector director)
        {
            onAnimationFinish.Invoke();
        }
    }
}