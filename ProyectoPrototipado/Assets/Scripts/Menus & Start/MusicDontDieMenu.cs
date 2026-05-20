using UnityEngine;

public class MusicDontDieMenu : MonoBehaviour
{
    private static MusicDontDieMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
