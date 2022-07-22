using EventApplication.Filters;
using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{

    public class BookingController : Controller
    {
        IBookingRepository Ibook;

        public BookingController()
        {
            Ibook = new BookingRepository(new EventDBEntities());
        }

        [HttpPost]
        [ValidateUserSession]
        public JsonResult CheckBooking(BookingDetail BookingDetail, BookingVenue objBV)
        {
            try
            {
                if (BookingDetail != null && objBV != null)
                {
                    bool result = Ibook.checkBookingAvailability(BookingDetail, objBV);
                    if (result == false)
                    {
                        return Json("NotAvailable");
                    }
                    else
                    {
                        return Json("Available");
                    }
                }
                else
                {
                    return Json("Available");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        [ValidateUserSession]
        public JsonResult BookEvent(BookingDetail BookingDetail, BookingVenue BookingVenue)
        {

            try
            {
                if (BookingDetail != null && BookingVenue != null)
                {
                    BookingDetail BD = new BookingDetail
                    {
                        BookingDate = BookingDetail.BookingDate,
                        Createdby = Convert.ToInt32(Session["UserID"]),
                        CreatedDate = DateTime.Now,
                        BookingApproval = "P",
                        BookingCompletedFlag = "P"
                    };

                    var result = Ibook.BookEvent(BD);

                    BookingVenue BV = new BookingVenue
                    {
                        VenueID = BookingVenue.VenueID,
                        EventTypeID = BookingVenue.EventTypeID,
                        GuestCount = BookingVenue.GuestCount,
                        Createdby = Convert.ToInt32(Session["UserID"]),
                        CreatedDate = DateTime.Now,
                        BookingID = result
                    };

                    var VenueID = Ibook.BookVenue(BV);

                    Session["BookingID"] = result;

                    string BookingNo = Ibook.BookingNoByBookingID(result);

                    if (result > 0)
                    {
                        return Json(BookingNo);
                    }
                    else
                    {
                        return Json("Failed");
                    }
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        [ValidateAdminSession]
        public JsonResult CancelBooking(int BookingID)
        {
            try
            {
                if (BookingID != 0)
                {

                    var result = Ibook.CancelBooking(BookingID);

                    if (result > 0)
                    {
                        return Json("Success");
                    }
                    else
                    {
                        return Json("Failed");
                    }
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpGet]
        [ValidateUserSession]
        public JsonResult ShowBookingDetails()
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
                {
                    var result = Ibook.ShowBookingDetail(Convert.ToInt32(Session["UserID"]));

                    if (result.Count() > 0)
                    {

                        List<BookingDetailTemp> resultnew = new List<BookingDetailTemp>();

                        foreach (var item in result)
                        {
                            BookingDetailTemp BT = new BookingDetailTemp();

                            DateTime? BDT = item.BookingDate;
                            string BookingDate = BDT.Value.ToString("dd/MM/yyyy");

                            DateTime? BDTA = item.BookingApprovalDate;
                            string BookingApprovalDate;

                            if (item.BookingApprovalDate == null)
                            {
                                BookingApprovalDate = "Booking Pending";
                            }
                            else
                            {
                                BookingApprovalDate = BDTA.Value.ToString("dd/MM/yyyy");
                            }
                            BT.BookingNo = item.BookingNo;
                            BT.BookingID = item.BookingID;
                            BT.BookingDate = BookingDate;

                            string BookingApproval;

                            if (item.BookingCompletedFlag == "P")
                            {
                                BookingApproval = "Application Not Filled Completed";
                            }
                            else if (item.BookingApproval == "P")
                            {
                                BookingApproval = "Pending";
                            }
                            else if (item.BookingApproval == "C")
                            {
                                BookingApproval = "Cancelled";
                            }
                            else if (item.BookingApproval == "A")
                            {
                                BookingApproval = "Approved";
                            }
                            else
                            {
                                BookingApproval = "Application Not Filled Completed";
                            }

                            BT.BookingApproval = BookingApproval;
                            BT.BookingApprovalDate = BookingApprovalDate;
                            resultnew.Add(BT);
                        }

                        return Json(resultnew, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Failed");
                    }
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpGet]
        [ValidateAdminSession]
        public JsonResult ShowBookingDetailsAdmin()
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
                {
                    var result = Ibook.ShowBookingDetail();

                    if (result.Count() > 0)
                    {

                        List<BookingDetailTemp> resultnew = new List<BookingDetailTemp>();

                        foreach (var item in result)
                        {
                            BookingDetailTemp BT = new BookingDetailTemp();

                            DateTime? BDT = item.BookingDate;
                            string BookingDate = BDT.Value.ToString("dd/MM/yyyy");

                            DateTime? BDTA = item.BookingApprovalDate;
                            string BookingApprovalDate;

                            if (item.BookingApprovalDate == null)
                            {
                                BookingApprovalDate = "Booking Pending";
                            }
                            else
                            {
                                BookingApprovalDate = BDTA.Value.ToString("dd/MM/yyyy");
                            }
                            BT.BookingNo = item.BookingNo;
                            BT.BookingID = item.BookingID;
                            BT.BookingDate = BookingDate;
                            string BookingApproval = string.Empty;

                            if (item.BookingCompletedFlag == "P")
                            {
                                BookingApproval = "Application Not Filled Completed";
                            }
                            else if (item.BookingApproval == "P")
                            {
                                BookingApproval = "Pending";
                            }
                            else if (item.BookingApproval == "C")
                            {
                                BookingApproval = "Cancelled";
                            }
                            else if (item.BookingApproval == "A")
                            {
                                BookingApproval = "Approved";
                            }


                            BT.BookingApproval = BookingApproval;
                            BT.BookingApprovalDate = BookingApprovalDate;
                            resultnew.Add(BT);
                        }

                        return Json(resultnew, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Failed");
                    }
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        [ValidateAdminSession]
        public JsonResult UpdateBookingStatus(string BookingID, string BookingStatus)
        {
            try
            {
                if (!string.IsNullOrEmpty(BookingID))
                {
                    var result = Ibook.UpdateBookingStatus(BookingID, BookingStatus);
                    if (result > 0)
                    {
                        return Json("Success");
                    }
                    else
                    {
                        return Json("Failed");
                    }
                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
