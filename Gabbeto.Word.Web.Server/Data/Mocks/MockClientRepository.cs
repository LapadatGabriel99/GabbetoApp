using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The repository that handles the web socket clients
    /// </summary>
    public class MockClientRepository : IClientRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Adds a client to the database
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(WebSocketClient client)
        {
            _context.Clients.Add(client);

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a client from the database
        /// </summary>
        /// <returns></returns>
        public WebSocketClient GetClient(string user)
        {
            return _context.Clients.Where(c => c.User == user).FirstOrDefault();
        }

        /// <summary>
        /// Removes a client from the database
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(WebSocketClient client)
        {
            _context.Clients.Remove(client);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a client in the database
        /// </summary>
        /// <param name="client"></param>
        public void UpdateClient(WebSocketClient client)
        {
            _context.Clients.Update(client);

            _context.SaveChanges();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The db context of this app
        /// </summary>
        ApplicationDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MockClientRepository(ApplicationDbContext context)
        {
            // Set the context
            _context = context;
        }

        #endregion
    }
}
