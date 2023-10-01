using ApiService.Service.Httpz;

namespace ApiService.Service.User.Httpz
{
    /// <summary>
    /// Implementazione dell'interfaccia IUserHttpClient per le operazioni HTTP relative agli utenti.
    /// </summary>
    public class UserHttpClient : BaseHttpClient, IUserHttpClient
    {
        /// <summary>
        /// Crea un'istanza di UserHttpClient.
        /// </summary>
        /// <param name="httpClient">Client HTTP da utilizzare per le richieste.</param>
        public UserHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/user/")
        {
        }
    }
}
