﻿using Microsoft.EntityFrameworkCore;
using ParkStroiteleyMVC.Models;
using ParkStroiteleyMVC.Models.ObjectDTO;
using ParkStroiteleyMVC.Controllers.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.HomeCore
{
    public struct HomeDigger : IDigger
    {
        private DBContext Context;
        public bool IsDispose { get; set; }


        public ContactsDTO GetContacts()
        {
            var contacts = Context.Contacts.FirstOrDefault();
            return contacts;
        }

        #region [IDisposable]
        public void Connect()
        {
            Context = new DBContext(new DbContextOptions<DBContext>());
            IsDispose = false;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context = null;
            IsDispose = true;
        }
        #endregion
    }
}
