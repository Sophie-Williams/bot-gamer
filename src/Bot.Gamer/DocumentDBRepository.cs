using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Bot.Gamer
{
    public class DocumentDbRepository
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["database"];
        private static readonly string CollectionId = ConfigurationManager.AppSettings["collection"];
        private static readonly string EndpointUri = ConfigurationManager.AppSettings["docummentEndpoint"];
        private static readonly string PrimaryKey = ConfigurationManager.AppSettings["docummentKey"];
        private static DocumentClient _client;
        private static Uri _collectionLink;

        public DocumentDbRepository()
        {
            _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            _collectionLink = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);
        }

        public async Task<Inscricao> GetItemAsync(string id)
        {
            try
            {
                Document document = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (Inscricao)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }


            //if (cs.Length > 2)
            //{

            //}

            //if (employeeResponse.Email.Split('@')[1] == "esx.com.br")
            //{

            //}

            //var docs = _client.ReadDocumentFeedAsync(collectionLink, new FeedOptions { MaxItemCount = 50 }).Result.ToList();

            //foreach (var item in docs)
            //{
            //    var d = (Inscricao)(dynamic)item;
            //    Console.WriteLine(d.Email);
            //}
        }

        public List<Inscricao> ListItemAsync()
        {
            try
            {
                var document = _client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions { MaxItemCount = 50 }).Result.ToList();
                //Document document = await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                var inscricoes = new List<Inscricao>();
                foreach (var item in document)
                {
                    var d = (Inscricao)(dynamic)item;
                    inscricoes.Add(new Inscricao(){ Email = d.Email });
                }

                return inscricoes;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }


            //if (cs.Length > 2)
            //{

            //}

            //if (employeeResponse.Email.Split('@')[1] == "esx.com.br")
            //{

            //}

            //var docs = _client.ReadDocumentFeedAsync(collectionLink, new FeedOptions { MaxItemCount = 50 }).Result.ToList();

            //foreach (var item in docs)
            //{
            //    var d = (Inscricao)(dynamic)item;
            //    Console.WriteLine(d.Email);
            //}
        }

        public Inscricao GetItemByEmailAsync(string email)
        {
            try
            {
                return _client.CreateDocumentQuery<Inscricao>(_collectionLink)
                    .Where(so => so.Email == email)
                    .AsEnumerable()
                    .FirstOrDefault();
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Inscricao> CreateItemAsync(Inscricao item)
        {
            var created = await _client.CreateDocumentAsync(_collectionLink, item);
            var employeeResult = (Inscricao)(dynamic)created.Resource;
            return employeeResult;
        }
    }

    [Serializable]
    public class Inscricao
    {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }
    }
}