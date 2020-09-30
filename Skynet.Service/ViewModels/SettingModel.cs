using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.ViewModels
{
   
    public class SettingModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Notes { get; set; }
        public System.DateTime DateCreatedUTC { get; set; }
        public System.DateTime DateModifiedUTC { get; set; }
    }

    public class SettingRepository
    {
        private IUnitOfWork _unitOfWork;
        //private AcademyLockSmith_LiveContext _context;
        public SettingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // _context = context;
        }


        public string T(string name, string notes)
        {
            var setting = _unitOfWork.GenericRepository<Setting>().GetSingle(x => x.Name.Equals(name));
            if (setting != null)
            {
                if (!string.IsNullOrEmpty(notes))
                {
                    return setting.Notes;
                }
                else
                {
                    return setting.Value;
                }
            }
            else
            {
                //_unitOfWork.SettingRepository.Insert(new Setting { Code = name, Value = notes, Name = name, DateCreatedUTC = DateTime.Now, DateModifiedUTC = DateTime.Now, Notes = notes });
                //_unitOfWork.Save();

                return "";
            }
        }

        public string GetOrCreate(string name, string notes)
        {
            var setting = _unitOfWork.GenericRepository<Setting>().GetSingle(x => x.Name == name);
            if (setting != null)
            {
                if (!string.IsNullOrEmpty(notes))
                {
                    return setting.Notes;
                }
                else
                {
                    return setting.Value;
                }
            }
            else
            {
                _unitOfWork.GenericRepository<Setting>().Insert(new Setting { Code = name, Value = notes, Name = name, DateCreatedUtc = DateTime.Now, DateModifiedUtc = DateTime.Now, Notes = notes });
                _unitOfWork.Save();

                return notes;
            }
        }
    }
}
