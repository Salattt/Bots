using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private Bot _blueprint;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BotHandler _handler;

    private Resource _resource;

    public void SetupResource(Resource resource)
    {
        _resource = resource;
    }

    public void Spawn()
    {
        Bot bot = Instantiate(_blueprint, _spawnPoint.position,_spawnPoint.localRotation);

        _handler.Add(bot);
        bot.Startup(_resource);
    }
}
