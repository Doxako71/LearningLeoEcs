namespace Client
{
    using UnityEngine;

    public class EntityConvertor : MonoBehaviour
    {
        private void Start()
        {
            WordProvider.NewEntity(this);
        }
    }
}