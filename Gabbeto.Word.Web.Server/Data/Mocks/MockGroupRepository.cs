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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a group from the database
        /// </summary>
        /// <returns></returns>
        public WebSocketGroup GetGroup()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a group from the database
        /// </summary>
        /// <param name="group"></param>
        public void RemoveGroup(WebSocketGroup group)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a group in the database
        /// </summary>
        /// <param name="group"></param>
        public void UpdateGroup(WebSocketGroup group)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}
