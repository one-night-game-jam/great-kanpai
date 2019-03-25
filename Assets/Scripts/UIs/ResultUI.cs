using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

using Managers;

namespace UIs
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField]
        Button restartGameButton;
        public IObservable<Unit> OnRestartGame => restartGameButton.OnClickAsObservable().AsUnitObservable();

        void OnEnable()
        {
            restartGameButton.Select();
        }
    }
}