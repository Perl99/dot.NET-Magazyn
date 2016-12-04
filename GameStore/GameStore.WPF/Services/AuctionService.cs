using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;
using GameStore.REST.Services;

namespace GameStore.WPF.Services
{
    public class AuctionServiceClient : ClientBase<IAuctionService>, IAuctionService
    {

        public AuctionServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public AuctionServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuctionServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuctionServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        List<AuctionJson> IAuctionService.List()
        {
            List<AuctionJson> auctions;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                auctions = Channel.List();
            }

            return auctions;
        }

        public void Save(AuctionJson json)
        {
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                Channel.Save(json);
            }
        }

        AuctionJson IAuctionService.Get(string id)
        {
            AuctionJson auction;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                auction = Channel.Get(id);
            }

            return auction;
        }
    }
}
