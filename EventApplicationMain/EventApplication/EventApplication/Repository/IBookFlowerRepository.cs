using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface IBookFlowerRepository
    {
        int BookFlower(Models.BookingFlower BookingFlower);
    }
}
