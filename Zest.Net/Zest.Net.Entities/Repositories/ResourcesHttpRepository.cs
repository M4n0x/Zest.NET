using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    /// <summary>
    /// Resources Http repository
    /// </summary>
    public class ResourcesHttpRepository : GenericHttpRepository<Resource>
    {
        /// <summary>
        /// Resources Http repository constructor
        /// </summary>
        /// <param name="client">Zest client</param>
        public ResourcesHttpRepository(ZestClient client) : base(client)
        {
            // nothing
        }

        /// <summary>
        /// Get Booking path with ShareId
        /// </summary>
        /// <param name="shareId">ShareId</param>
        /// <returns>Api path</returns>
        private string BookingApiPath(string shareId) => $"{ApiPath}/{shareId}";

        /// <summary>
        /// Get bookings and resource info with shareid
        /// </summary>
        /// <param name="shareId">Resource shareId</param>
        /// <returns>Api response with Resource and its bookings</returns>
        public async Task<IEnumerable<Resource>> GetBookings(string shareId)
        {
            return await _client.Get<Resource>(BookingApiPath(shareId));
        }

        /// <summary>
        /// Post a Booking for a given resource
        /// </summary>
        /// <param name="shareId">Resource shareId</param>
        /// <param name="booking">Booking to create</param>
        /// <returns>Task</returns>
        public async Task<Booking> PostBooking(string shareId, Booking booking)
        {
            return await _client.Insert($"{BookingApiPath(shareId)}/bookings", booking);
        }

        /// <summary>
        /// Delete a Booking for a given Resource
        /// </summary>
        /// <param name="shareId">Resource shareId</param>
        /// <param name="id">Booking id</param>
        /// <returns>Task</returns>
        public async Task DeleteBooking(string shareId, int id)
        {
            await _client.Delete<Booking>($"{BookingApiPath(shareId)}/bookings", id);
        }

        public async Task<Resource> Insert(Resource entity, bool multipart = false)
        {
            return await _client.Request<Resource, Resource>(ApiPath, HttpMethod.Post, entity, multipart);
        }

        public async Task<Resource> Update(string id, Resource entity, bool multipart = false)
        {
            return await _client.Update(ApiPath, id, entity, multipart);
        }
    }
}