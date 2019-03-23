using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

using Managers;

namespace UIs
{
    public class TitleUI : MonoBehaviour
    {
        // [SerializeField]
        // Button startOnePlayerModeButton;
        [SerializeField]
        Button startTwoPlayerModeButton;

        public IObservable<GameMode> OnSelectGameMode
        {
            get
            {
                // var startOnePlayer = startOnePlayerModeButton
                //     .OnClickAsObservable()
                //     .Select(_ => GameMode.OnePlayer);
                // var startTwoPlayer = startTwoPlayerModeButton
                //     .OnClickAsObservable()
                //     .Select(_ => GameMode.TwoPlayer);
                // return Observable.Merge(startOnePlayer, startTwoPlayer);
                return startTwoPlayerModeButton
                    .OnClickAsObservable()
                    .Select(_ => GameMode.TwoPlayer);
            }
        }
    }
}