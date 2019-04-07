using UnityEngine;
using Zenject;

namespace Players
{
    public class MaterialSwitcher : MonoBehaviour
    {
        [SerializeField]
        Renderer renderer;

        [SerializeField]
        Material[] materials;

        [Inject]
        int playerNum;

        void Start()
        {
            renderer.material = materials[playerNum];
        }
    }
}
