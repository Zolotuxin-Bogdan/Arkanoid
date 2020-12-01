using UnityEngine;

public class SessionStorage
{
    private static SessionStorage _instance;
    private static object syncRoot = new Object();

    public bool GameLoaded { get; set; }
    public int LoadCellIndex { get; set; }

    public static SessionStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new SessionStorage();
                }
            }
            return _instance;
        }
    }
}
