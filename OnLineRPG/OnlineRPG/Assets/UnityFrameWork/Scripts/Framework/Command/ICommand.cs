using System;
using UnityEngine.Events;

namespace BetaFramework
{
    public interface ICommand
    {
        void Initilize();

        void Execute();

        void Release();

        object Data { get; set; }
    }
}