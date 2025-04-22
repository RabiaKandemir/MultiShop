using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTime.Services.SignalRCommentServices;
using MultiShop.SignalRRealTime.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTime.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRMessageService signalRService, ISignalRCommentService signalRCommentService)
        {
            _signalRMessageService = signalRService;
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
            //var getTotalMessageCountByReceiverId = await _signalRMessageService.GetTotalMessageCountByReceiverId(id);
            //await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCountByReceiverId);
        }
    }
}
