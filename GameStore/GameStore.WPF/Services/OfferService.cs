using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;
using GameStore.REST.Services;

namespace GameStore.WPF.Services
{
    public class OfferServiceClient : ClientBase<IOfferService>, IOfferService
    {

        public OfferServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public OfferServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OfferServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OfferServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public List<OfferJson> List(string auctionId)
        {
            List<OfferJson> offers;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                offers = Channel.List(auctionId);
            }

            return offers;
        }

        public void Save(string auctionId, OfferJson json)
        {
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                Channel.Save(auctionId, json);
            }
        }

        public void Accept(string auctionId, string id)
        {
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                Channel.Accept(auctionId, id);
            }
        }

        public OfferJson Get(string id)
        {
            OfferJson offer;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                offer = Channel.Get(id);
            }

            return offer;
        }
    }
}
