namespace Client
{
    using Systems;
    using Leopotam.Ecs;
    using UnityEngine;

    [RequireComponent(typeof(WordProvider))]
    sealed class EcsStartup : MonoBehaviour
    {
        public EcsWorld World;
        private EcsSystems _systems;

        private void Awake()
        {
            // void can be switched to IEnumerator for support coroutines.

            World   = new EcsWorld();
            _systems = new EcsSystems(World);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems); 
#endif
            _systems
                // register your systems here, for example:
                .Add (new TestSystem())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                World.Destroy();
                World = null;
            }
        }
    }
}