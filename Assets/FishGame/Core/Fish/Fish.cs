using FishGame.Model;
using UnityEngine;

namespace FishGame.Core.Fish
{
    [RequireComponent(typeof(FishController))]
    public class Fish : MonoBehaviour
    {
        public FishModel Data { get; private set; }

        private FishController _fishController;
        
        private void Awake()
        {
            _fishController = GetComponent<FishController>();
        }

        public void SetData(FishModel data)
        {
            Data = data;
            
            // Apply given data to FishController
            _fishController.ApplyData(Data);
        }
    }
}