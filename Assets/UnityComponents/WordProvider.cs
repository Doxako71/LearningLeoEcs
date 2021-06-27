namespace Client
{
    using System.Collections.Generic;
    using Components;
    using Leopotam.Ecs;
    using UnityEngine;

    public class WordProvider : MonoBehaviour
    {
        private static EcsStartup _ecsStartup;

        private void Awake()
        {
            _ecsStartup = GetComponent<EcsStartup>();
        }

        
        public static void NewEntity(MonoBehaviour monoBehaviour)
        {
            var entity = _ecsStartup.World.NewEntity();
            entity.Get<MonoBehaviourComponent>().MonoBehaviour = monoBehaviour;
        }
    }
}