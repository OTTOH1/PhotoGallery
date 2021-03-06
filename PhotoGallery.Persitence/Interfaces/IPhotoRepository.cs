﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Domain;

namespace PhotoGallery.Persistence.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        IEnumerable<Photo> GetPhotosByUserId(string userId);
        void RemoveIncludingBytesContent(Photo photo);
        void Modify(Photo photo);
        byte[] GetOriginalPhoto(int photoId);
        byte[] GetMediumPhoto(int photoId);
        byte[] GetThumbPhoto(int photoId);
        IEnumerable<Photo> Search(Photo photoModel, string userId);
        IEnumerable<Photo> SearchByName(string photoName, string userId);
    }
}
