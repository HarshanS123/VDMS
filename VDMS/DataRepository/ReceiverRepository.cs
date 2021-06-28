using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDMS.Interface;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.DataRepository
{
    public class ReceiverRepository : IReceiver
    {
        private ApplicationDbContext _dbcontext;
        ReceiverViewModel IReceiver.Create()
        {
            var reciver = new ReceiverViewModel();
            return reciver;
        }

        string IReceiver.Delete(int id)
        {
            throw new NotImplementedException();
        }

        ReceiverViewModel IReceiver.Detail(int id)
        {
            throw new NotImplementedException();
        }

        bool IReceiver.Edit(int id, Receiver receiver)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ReceiverViewModel> IReceiver.GetAll()
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                var res = _dbcontext.Receivers.ToList().Select(Mapper.Map<Receiver, ReceiverViewModel>);
                return res;
            }
        }

        IEnumerable<ReceiverViewModel> IReceiver.GetAvailable()
        {
            throw new NotImplementedException();
        }

        bool IReceiver.Save(Receiver viewModel)
        {
            using (_dbcontext = new ApplicationDbContext())
            {
                if (viewModel != null)
                {
                    _dbcontext.Receivers.Add(viewModel);
                    _dbcontext.SaveChanges();
                }

                return true;

            }
        }
    }
}