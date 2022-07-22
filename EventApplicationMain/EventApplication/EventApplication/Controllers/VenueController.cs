using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Filters;
namespace EventApplication.Controllers
{
    [ValidateAdminSession]
    public class VenueController : Controller
    {
        IVenueRepository _IVenueRepository;
        public VenueController()
        {
            _IVenueRepository = new VenueRepository(new EventDBEntities());
        }

        [HttpPost]
        public JsonResult SaveVenue(Venue Venue)
        {
            try
            {
                if (Venue != null)
                {
                    string Message, fileName, actualFileName;
                    Message = fileName = actualFileName = string.Empty;
                    bool flag = false;
                    if (Request.Files != null)
                    {
                        var file = Request.Files[0];
                        actualFileName = file.FileName;
                        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        int size = file.ContentLength;
                        try
                        {
                            file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                            Venue objvenue = new Venue
                            {
                                VenueFilename = actualFileName,
                                VenueFilePath = fileName,
                                VenueID = 0,
                                VenueName = Venue.VenueName,
                                VenueCost = Venue.VenueCost,
                                Createdby = Convert.ToInt32(Session["UserID"])
                            };

                            _IVenueRepository.SaveVenue(objvenue);

                            Message = "Venue Saved Successfully";
                            flag = true;
                        }
                        catch (Exception)
                        {
                            Message = "Venue Save failed! Please try again";
                        }

                    }
                    return new JsonResult { Data = new { Message = Message, Status = flag } };

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
        public JsonResult UpdateVenue(Venue Venue)
        {
            try
            {
                if (Venue != null)
                {
                    string Message, fileName, actualFileName;
                    Message = fileName = actualFileName = string.Empty;
                    bool flag = false;

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        actualFileName = file.FileName;
                        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        int size = file.ContentLength;
                        file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                        Venue objvenue = new Venue
                          {
                              VenueFilename = actualFileName,
                              VenueFilePath = fileName,
                              VenueID = Venue.VenueID,
                              VenueName = Venue.VenueName,
                              VenueCost = Venue.VenueCost
                          };

                        _IVenueRepository.UpdateVenue(objvenue);

                    }
                    else
                    {

                        Venue objvenue = new Venue
                         {
                             VenueID = Venue.VenueID,
                             VenueName = Venue.VenueName,
                             VenueCost = Venue.VenueCost
                         };



                        _IVenueRepository.UpdateVenue(objvenue);
                    }

                    Message = "Venue Updated Successfully";
                    flag = true;


                    return new JsonResult { Data = new { Message = Message, Status = flag } };
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
