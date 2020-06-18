using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The repository that handles the web socket groups
    /// </summary>
    public class MockGroupRepository : IGroupRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Adds a group to the database
        /// </summary>
        /// <param name="group"></param>
        public void AddGroup(WebSocketGroup group)
        {
            _context.Groups.Add(group);

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a group from the database
        /// </summary>
        /// <returns></returns>
        public WebSocketGroup GetGroup(string name)
        {
            return _context.Groups.Where(g => g.Name == name).FirstOrDefault();
        }

        /// <summary>
        /// Removes a group from the database
        /// </summary>
        /// <param name="group"></param>
        public void RemoveGroup(WebSocketGroup group)
        {
            _context.Groups.Remove(group);

            _context.SaveChanges();            
        }

        /// <summary>
        /// Updates a group in the database
        /// </summary>
        /// <param name="group"></param>
        public void UpdateGroup(WebSocketGroup group)
        {
            _context.Groups.Update(group);

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
        public MockGroupRepository(ApplicationDbContext context)
        {
            // Set the context
            _context = context;
        }

        #endregion
    }
}
