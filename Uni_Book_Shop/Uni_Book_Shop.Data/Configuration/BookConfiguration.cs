using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Uni_Book_Shop.Data.Configuration
{
    static class BookConfigiration
    {
        public static void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(x => x.Id);
        }
    }
}
