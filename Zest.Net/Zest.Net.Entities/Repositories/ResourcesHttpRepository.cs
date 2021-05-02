using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{
    public class BookingsGet
    {
        public int Id { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public User Author { get; set; }

    }

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
        public async Task<BookingsGet> GetBookings(string shareId)
        {
            return await _client.GetSingle<BookingsGet>(BookingApiPath(shareId));
        }

        /// <summary>
        /// Post a Booking for a given resource
        /// </summary>
        /// <param name="shareId">Resource shareId</param>
        /// <param name="booking">Booking to create</param>
        /// <returns>Task</returns>
        public async Task<BookingPostResponse> PostBooking(string shareId, Booking booking)
        {
            BookingPost bp = new BookingPost
            {
                DateStart = booking.DateStart,
                DateEnd = booking.DateEnd,
                User = booking.User.Id
            };

             return await _client.Request<BookingPostResponse, BookingPost>($"{BookingApiPath(shareId)}/bookings", HttpMethod.Post, bp);
        }

        /// <summary>
        /// Delete a Booking for a given Resource
        /// </summary>
        /// <param name="shareId">Resource shareId</param>
        /// <param name="id">Booking id</param>
        /// <returns>Task</returns>
        public async Task DeleteBooking(string shareId, int id)
        {
            //BUG ????
            await _client.Delete($"{BookingApiPath(shareId)}/bookings", id);
        }
    }
}