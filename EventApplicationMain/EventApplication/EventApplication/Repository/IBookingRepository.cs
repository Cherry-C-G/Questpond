using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface IBookingRepository
    {
        bool checkBookingAvailability(Models.BookingDetail objBD, BookingVenue objBV);
        int BookEvent(BookingDetail BookingDetail);
        int CancelBooking(int? BookingID);
        int? BookVenue(Models.BookingVenue objBV);
        IEnumerable<BookingDetail> ShowBookingDetail(int UserID);
        IEnumerable<BookingDetail> ShowBookingDetail();
        int UpdateBookingStatus(string BookingNo, string BookingStatus);
        void UpdateCompleted_Event_Status(int BookingID, string BCflag);
        string BookingNoByBookingID(int BookingID);
    }
}
