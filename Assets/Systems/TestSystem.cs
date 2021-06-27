namespace Client.Systems
{
    using Components;
    using Leopotam.Ecs;
    using UnityEngine;

    public class TestSystem : IEcsPreInitSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<MonoBehaviourComponent> _filter;
        
        public void PreInit()
        {
            
        }

        public void Run()
        {
        }

        public void Init()
        {
            foreach (var i in _filter)
            {
                ref var mono = ref _filter.Get1(i);
                Debug.Log(mono.MonoBehaviour.name);
            }
        }
    }
}