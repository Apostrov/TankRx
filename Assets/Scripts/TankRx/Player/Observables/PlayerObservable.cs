using System;
using TankRx.Player.Interfaces;
using UniRx;
using UnityEngine;

namespace TankRx.Player.Observables
{
    public class PlayerObservable : IPlayerObservable
    {
        public IObservable<Vector3?> PlayerPosition => PlayerPositionObservable();

        private GameObject _player;
        private bool _isPlayerRegistered;

        public void RegisterPlayer(GameObject player)
        {
            _isPlayerRegistered = true;
            _player = player;
        }

        public void UnregisterPlayer()
        {
            _isPlayerRegistered = false;
        }

        private IObservable<Vector3?> PlayerPositionObservable()
        {
            return Observable.EveryUpdate().Select(_ =>
            {
                if (_isPlayerRegistered == false)
                    return null;
                return (Vector3?)_player.transform.position;
            });
        }
    }
}