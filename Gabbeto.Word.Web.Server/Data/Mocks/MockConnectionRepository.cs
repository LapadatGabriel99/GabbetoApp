using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server 
{
    /// <summary>
    /// The repository that handles web socket connections
    /// </summary>
    public class MockConnectionRepository : IConnectionRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Adds a connection to the database
        /// </summary>
        /// <param name="client"></param>
        public void AddConnection(WebSocketConnection connection)
        {
            _context.Connections.Add(connection);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a connection in the database
        /// </summary>
        /// <param name="client"></param>
        public WebSocketConnection GetConnection(string connection)
        {
            return _context.Connections.Where(c => c.ConnectionId == connection).FirstOrDefault();
        }

        /// <summary>
        /// Removes a connection from the database
        /// </summary>
        /// <param name="client"></param>
        public void RemoveConnection(WebSocketConnection connection)
        {
            _context.Connections.Remove(connection);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a connection in the database
        /// </summary>
        /// <param name="client"></param>
        public void UpdateConnection(WebSocketConnection connection)
        {
            _context.Connections.Update(connection);

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the connections of a specific client
        /// </summary>
        /// <param name="Client">The specified client</param>
        /// <returns></returns>
        public ICollection<WebSocketConnection> GetConnections(WebSocketClient client)
        {
            return _context.Connections.Where(c => c.ClientId == client.Id).ToList();
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
        public MockConnectionRepository(ApplicationDbContext context)
        {
            // Set the context
            _context = context;
        }

        #endregion
    }
}
