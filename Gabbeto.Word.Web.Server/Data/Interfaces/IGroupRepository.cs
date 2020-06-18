using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The interface for the repository that handles web socket groups
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        /// Adds a group to the database
        /// </summary>
        /// <param name="group"></param>
        void AddGroup(WebSocketGroup group);

        /// <summary>
        /// Updates a group in the database
        /// </summary>
        /// <param name="group"></param>
        void UpdateGroup(WebSocketGroup group);

        /// <summary>
        /// Removes a group from the database
        /// </summary>
        /// <param name="group"></param>
        void RemoveGroup(WebSocketGroup group);

        /// <summary>
        /// Gets a group from the database
        /// </summary>
        /// <returns></returns>
        WebSocketGroup GetGroup(string name);
    }
}
