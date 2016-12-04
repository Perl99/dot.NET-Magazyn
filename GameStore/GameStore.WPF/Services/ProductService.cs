using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;
using GameStore.REST.Services;

namespace GameStore.WPF.Services
{
    public class ProductServiceClient : ClientBase<IProductService>, IProductService
    {

        public ProductServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ProductServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ProductServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }


        public ProductJson Get(string id)
        {
            ProductJson product;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                product = Channel.Get(id);
            }

            return product;
        }

        public List<ProductJson> List()
        {
            List<ProductJson> products;
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                products = Channel.List();
            }

            return products;
        }

        public void Save(ProductJson json)
        {
            using (new OperationContextScope(InnerChannel))
            {
                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                Session.GetInstance.ApplyHeaders(context.OutgoingRequest.Headers);

                Channel.Save(json);
            }
        }
    }
}
