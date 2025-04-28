using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface IGalleryPostService
    {
        IEnumerable<GalleryPost> GetAllGalleryPosts();
        GalleryPost GetGalleryPostById(int id);
        void CreateGalleryPost(GalleryPost GalleryPost);
        void UpdateGalleryPost(GalleryPost GalleryPost);
        void DeleteGalleryPost(GalleryPost GalleryPost);
    }
}
