using Starlight.Network;

namespace Starlight.Server.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly Configuration configuration;
        private readonly StarlightServer server;
        private readonly ConnectedUserManager connectedUserManager;

        public NetworkDispatch(Configuration configuration, StarlightServer server) : base(typeof(NetworkDispatch).Assembly)
        {
            this.configuration = configuration;
            this.server = server;

            this.connectedUserManager = new ConnectedUserManager();
        }

        protected override RequestContext BuildRequestContext(int connectionId)
        {
            return new RequestContext(connectionId, configuration, server, connectedUserManager);
        }

        protected override void OnRequestCompleted(RequestContext requestContext)
        {
            if (requestContext.DbContext.ChangeTracker.HasChanges())
            {
                requestContext.DbContext.SaveChanges();
            }
        }
    }
}
