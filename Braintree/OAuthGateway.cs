using System.Xml;

namespace Braintree
{
    public class OAuthGateway
    {
        private BraintreeService Service;

        public OAuthGateway(BraintreeService service)
        {
            Service = service;
        }

        public ResultImpl<OAuthCredentials> CreateTokenFromCode(OAuthCredentialsRequest request)
        {
            request.GrantType = "authorization_code";
            XmlNode accessTokenXML = Service.Post("/oauth/access_tokens", request);

            return new ResultImpl<OAuthCredentials>(new NodeWrapper(accessTokenXML), Service);
        }
    }
}
