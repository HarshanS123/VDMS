using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Models;
using System.Net;
using System.Data.Entity;
using VDMS.ViewModel;
using VDMS.Interface;

namespace VDMS.DataRepository
{
    public class ReceiverRecordRepository : IReceiverRecord
    {
        private ApplicationDbContext _dbcontext;
        private IVehicaleRepository _vehicale = new VehicalRepository();
        private IReceiver _receiver = new ReceiverRepository();
        ReceiverRecordViewModel IReceiverRecord.CreatrView()
        {
            var recRecord = new ReceiverRecordViewModel();
            var vehical =   _vehicale.GetAllVehicle();
            var reciver = _receiver.GetAll();            
            recRecord.Vehicles = vehical;
            recRecord.Receivers = reciver;
            return recRecord;

        }

        ReceiverRecordViewModel IReceiverRecord.EditCreatrView(int id)
        {            
            
            using (_dbcontext = new ApplicationDbContext())
            {
                var obj = _dbcontext.ReceiverRecords.Where(r => r.Id == id).Include(v => v.Vehicle).Include(r => r.Receiver).FirstOrDefault();
                var recRecord = Mapper.Map<ReceiverRecord, ReceiverRecordViewModel>(obj);
                var vehical = _vehicale.GetAllVehicle();
                var reciver = _receiver.GetAll();
                recRecord.Vehicles = vehical;
                recRecord.Receivers = reciver;                
                return recRecord;
            }
            

        }

        IEnumerable<ReceiverRecordViewModel> IReceiverRecord.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.ReceiverRecords.Where(r => r.TerminateDate == null).Include(v => v.Vehicle).Include(r => r.Receiver).ToList().Select(Mapper.Map<ReceiverRecord, ReceiverRecordViewModel>);
                return res;
            }
        }

        bool IReceiverRecord.Save(ReceiverRecord record)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                if (record != null)
                {
                    _dbcontext.ReceiverRecords.Add(record);
                    _dbcontext.SaveChanges();
                }

                return true;

            }
        }

        bool IReceiverRecord.Terminate(int id, ReceiverRecord record)
        {
            var returnVal = false;
            using (_dbcontext = new ApplicationDbContext())
            {
                var dbrecord = _dbcontext.ReceiverRecords.Single(R => R.Id == id);
                if (dbrecord != null)
                {
                    dbrecord.TerminateDate = record.TerminateDate;                    
                    _dbcontext.SaveChanges();
                    returnVal = true;
                }

            }

            return returnVal;
        }
        
    }
}