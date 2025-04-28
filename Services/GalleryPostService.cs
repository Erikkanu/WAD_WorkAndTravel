using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;

namespace WAD_WorkAndTravel.Services
{
    public class GalleryPostService : IGalleryPostService
    {
        private readonly IRepositoryWrapper _repository;

        public GalleryPostService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<GalleryPost> GetAllGalleryPosts()
        {
            return _repository.GalleryPost.FindAll().ToList();
        }

        public GalleryPost GetGalleryPostById(int id)
        {
            return _repository.GalleryPost.FindByCondition(j => j.id == id).FirstOrDefault();
        }

        public void CreateGalleryPost(GalleryPost GalleryPost)
        {
            _repository.GalleryPost.Create(GalleryPost);
            _repository.Save();
        }

        public void UpdateGalleryPost(GalleryPost GalleryPost)
        {
            _repository.GalleryPost.Update(GalleryPost);
            _repository.Save();
        }

        public void DeleteGalleryPost(GalleryPost GalleryPost)
        {
            _repository.GalleryPost.Delete(GalleryPost);
            _repository.Save();
        }
    }
}
