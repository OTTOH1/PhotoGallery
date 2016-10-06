﻿using System.Collections.Generic;
using System.Linq;
using PhotoGallery.Domain;
using PhotoGallery.Persistence.Interfaces;
using PhotoGallery.Services.Interfaces;

namespace PhotoGallery.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Album> GetAlbumsOfTheUser(string userId)
        {
            return _unitOfWork.Albums.GetAlbumsByUserId(userId).ToList();
        }

        public Album GetAlbum(int albumId)
        {
            return _unitOfWork.Albums.Get(albumId);
        }

        public void AddAlbum(Album album)
        {
            _unitOfWork.Albums.Add(album);
            _unitOfWork.Complete();
        }

        public void Modify(Album album)
        {
            Album originalAlbum = _unitOfWork.Albums.Get(album.Id);
            originalAlbum.Description = album.Description;
            originalAlbum.Name = album.Name;
            _unitOfWork.Albums.Modify(originalAlbum);
            _unitOfWork.Complete();
        }

        public void Remove(int albumId)
        {
            Album album = _unitOfWork.Albums.Get(albumId);
            _unitOfWork.Albums.Remove(album);
            _unitOfWork.Complete();
        }

        public void AddPhotoToAlbum(int photoId, int albumId)
        {
            Album album = _unitOfWork.Albums.Get(albumId);
            Photo photo = _unitOfWork.Photos.Get(photoId);
            album.Photos.Add(photo);
            _unitOfWork.Complete();
        }

        public Album GetAlbumByShortenedName(string albumName)
        {
            albumName = albumName.Replace("-", " ");
            return _unitOfWork.Albums.SingleOrDefault(x => x.Name == albumName);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
