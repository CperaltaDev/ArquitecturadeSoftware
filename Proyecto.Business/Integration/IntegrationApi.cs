
using Newtonsoft.Json;
using Proyecto.Data.Common;
using Proyecto.Data.Dto;
using System.Net.Http.Headers;

namespace Proyecto.Business.Integration
{
    /// <summary>
    /// Clase abstracta para la integración de servicios Api 
    /// </summary>
    public abstract class IntegrationApi
    {
        /// <summary>
        /// Método para ejecutar la integracióm con una URI especifica 
        /// </summary>
        /// <param name="input">Objeto cuerpo de la solicitud</param>
        /// <param name="endpoint">URI de la solicitud</param>
        /// <param name="token">Token Bearer</param>
        /// <param name="verb">Verbo HttpRequest</param>
        /// <returns>HttpResponseMessage, objeto que se obtiene en la integración</returns>
        public static async Task<HttpResponseMessage> Execute(object input, string endpoint, string token, HttpRequestType verb)
        {
            HttpResponseMessage output = new ();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            var jsonContent = JsonConvert.SerializeObject(input);
            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonContent);
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            switch (verb)
            {
                case HttpRequestType.POST:
                    output = await client.PostAsync(endpoint, byteContent);
                    break;
                case HttpRequestType.GET:
                    output = await client.GetAsync(endpoint);
                    break;
            }


            return output;
        }
        /// <summary>
        /// Método abstracto para obtener token interno JWT api Security
        /// </summary>
        /// <param name="input">Objeto TokenIn, nombre de usuario y clave</param>
        /// <returns>TokenOut, Objeto con el token más la entidad BaseOut</returns>


        /// <summary>
        /// Método abstracto para obtener token JWT de integraciones externas
        /// </summary>
        /// <param name="input">Objeto TokenIn, nombre de usuario y clave</param>
        /// <returns>TokenOut, Objeto con el token más la entidad BaseOut</returns>


    }
}
