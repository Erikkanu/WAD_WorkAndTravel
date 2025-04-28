using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class GalleryPostRepository : RepositoryBase<GalleryPost>, IGalleryPostRepository
    {
        public GalleryPostRepository(WAT_Context context) : base(context)
        {
        }
    }
}
