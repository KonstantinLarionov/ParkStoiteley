using Microsoft.EntityFrameworkCore;
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
        #region [Const/Props]
        private const int CountPreviewNews = 6;
        private const int CountPreviewGallery = 9;
        private DBContext Context;
        public bool IsDispose { get; set; }
        #endregion

        public ContactsDTO GetContacts()
        {
            var contacts = Context.Contacts.FirstOrDefault();
            return contacts;
        }

        public List<NewDTO> GetNewsPreview()
        {
            List<NewDTO> news = null;
            news = Context.News
                .OrderByDescending(x => x.Id)
                .Take(CountPreviewNews)
                .Include(x=>x.Blocks)
                .ToList();
            news.Reverse();

            return news;
        }
        public List<GalleryDTO> GetGalleryPreview()
        {
            List<GalleryDTO> gallery = null;
            gallery = Context.Gallery
                .OrderByDescending(x => x.Id)
                .Take(CountPreviewGallery)
                .ToList();
            gallery.Reverse();

            return gallery;
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
