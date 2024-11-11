using UnityEngine;
using System.Collections.Generic;

public class BotHandler : MonoBehaviour
{
    private List<Bot> _bots = new List<Bot>();

    [SerializeField] private ResourceHolder _holder;
    [SerializeField] private MapResourceTransferer _transferer;

    private void OnEnable()
    {
        foreach (Bot bot in _bots) 
        {
            bot.ResourceCollected += OnBotCollectedResource;
            bot.ResourceDelivered += OnBotDeliveredResource;
        }
    }

    private void OnDisable()
    {
        foreach (Bot bot in _bots)
        {
            bot.ResourceCollected -= OnBotCollectedResource;
            bot.ResourceDelivered -= OnBotDeliveredResource;
        }
    }

    public void Add(Bot bot)
    {
        _bots.Add(bot);

        bot.ResourceCollected += OnBotCollectedResource;
        bot.ResourceDelivered += OnBotDeliveredResource;
    }

    private void OnBotDeliveredResource(Bot bot)
    {
        if (_holder.TryGetClosest(bot.Resource, bot.Transform.position, out MapResource resource))
            bot.SetupTargetResource(resource);
    }

    private void OnBotCollectedResource(Bot bot)
    {
        bot.MoveToPoint(_transferer.Transform.position);
    }
}
