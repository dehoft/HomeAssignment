using System.Net.Http;

namespace TesonetHomeAssignment.Core
{
    public sealed class Appcore
    {
        /// <summary>
        /// Vienintelis Appcore klases objektas (instance)
        /// </summary>
        private static readonly Appcore _instance = new Appcore();

        /// <summary>
        /// Vienintelis HttpClient klases objektas (instance)
        /// </summary>
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// [Singleton] Appcore klases objektas (vienintelis instance)
        /// </summary>
        public static Appcore Instance => _instance;

        /// <summary>
        /// [Singleton] HttpClient klases objektas (vienintelis instance)
        /// </summary>
        public static HttpClient Client = _client;

        public bool IsUserLoggedIn { get; set; }

        private Appcore()
        {

        }
    }
}
