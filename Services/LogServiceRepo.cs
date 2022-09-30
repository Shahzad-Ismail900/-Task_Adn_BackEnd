using CRUD.Common;
using CRUD.Interfaces;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class LogServiceRepo : ILogService
    {
        private readonly EDMSContext _context;
        public LogServiceRepo(EDMSContext context)
        {
            _context = context;
        }
        public ApiResponse CreateLog(LogUserActivity obj)
        {
            try
            {
                LogUserActivity _log = null;

                _log = obj.Id == 0 ? new LogUserActivity() : _context.LogUserActivity
                .FirstOrDefault(e => e.Id == obj.Id);

                _log.FormName = obj.FormName;
                _log.Action = obj.Action;
                _log.Status = obj.Status;
                _log.Description = obj.Description;
                _log.LogTime = DateTime.Now;
                _log.LoggedBy = obj.LoggedBy;
                _context.LogUserActivity.Add(_log);


                _context.SaveChanges();

                return (new ApiResponse { data = "Saved Successfully", isSucessful = true });
            }
            catch (Exception)
            {

                throw;
            }
        }

 
    }
}
