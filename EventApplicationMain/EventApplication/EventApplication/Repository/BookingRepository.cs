using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class BookingRepository : IBookingRepository
    {
        EventDBEntities _db;
        public BookingRepository(EventDBEntities eventDBEntities)
        {
            _db = eventDBEntities;
        }

        public bool checkBookingAvailability(Models.BookingDetail objBD, BookingVenue objBV)
        {
            try
            {
                if (objBD != null)
                {
                    var booking = (from Bb in _db.BookingDetails
                                   join BV in _db.BookingVenues on Bb.BookingID equals BV.BookingID
                                   where Bb.BookingDate == objBD.BookingDate && BV.VenueID == objBV.VenueID
                                   select Bb).Count();

                    if (booking > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int BookEvent(Models.BookingDetail BookingDetail)
        {
            try
            {
                if (BookingDetail != null)
                {
                    _db.BookingDetails.Add(BookingDetail);
                    _db.SaveChanges();

                    var currentBookingID = _db.BookingDetails.OrderByDescending(u => u.BookingID).FirstOrDefault();

                    var no = currentBookingID.BookingID.ToString() == "0" ? "1" : currentBookingID.BookingID.ToString();

                    var seq = "BK" + "-" + DateTime.Now.Year + "-" + no;

                    BookingDetail.BookingNo = seq;
                    _db.BookingDetails.Attach(BookingDetail);
                    _db.Entry(BookingDetail).Property(x => x.BookingNo).IsModified = true;
                    _db.SaveChanges();

                    return BookingDetail.BookingID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? BookVenue(Models.BookingVenue objBV)
        {
            try
            {
                _db.BookingVenues.Add(objBV);
                _db.SaveChanges();
                return objBV.VenueID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CancelBooking(int? BookingID = 0)
        {
            try
            {
                if (BookingID != 0)
                {
                    BookingDetail objBD = _db.BookingDetails.Find(BookingID);
                    objBD.BookingApproval = "A";
                    _db.Entry(objBD).Property(x => x.BookingApprovalDate).IsModified = true;
                    return _db.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BookingDetail> ShowBookingDetail(int UserID)
        {
            try
            {
                var ResultBookingDetail = (from tempBD in _db.BookingDetails
                                           where tempBD.Createdby == UserID
                                           select tempBD).ToList();

                return ResultBookingDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateBookingStatus(string BookingNo, string BookingStatus)
        {
            try
            {
                BookingDetail BD = (from BDs in _db.BookingDetails
                                    where BDs.BookingNo == BookingNo
                                    select BDs).Single();

                BD.BookingApproval = BookingStatus;
                BD.BookingApprovalDate = DateTime.Now;
                _db.BookingDetails.Attach(BD);
                _db.Entry(BD).Property(x => x.BookingApproval).IsModified = true;
                _db.Entry(BD).Property(x => x.BookingApprovalDate).IsModified = true;
                return _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BookingDetail> ShowBookingDetail()
        {
            try
            {
                var ResultBookingDetail = (from tempBD in _db.BookingDetails
                                           where tempBD.BookingCompletedFlag != "P"
                                           select tempBD).ToList();

                return ResultBookingDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCompleted_Event_Status(int BookingID, string BCflag)
        {
            try
            {
                if (BookingID != 0)
                {

                    BookingDetail BD = (from BDs in _db.BookingDetails
                                        where BDs.BookingID == BookingID
                                        select BDs).Single();

                    BD.BookingCompletedFlag = BCflag;
                    _db.BookingDetails.Attach(BD);
                    _db.Entry(BD).Property(x => x.BookingCompletedFlag).IsModified = true;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string BookingNoByBookingID(int BookingID)
        {
            try
            {
                var ResultBookingDetail = (from tempBD in _db.BookingDetails
                                           where tempBD.BookingID == BookingID
                                           select tempBD.BookingNo).Single();

                return ResultBookingDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}