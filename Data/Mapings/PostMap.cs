using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
    

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Chave primária config
            builder.ToTable("Post");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");
                
            builder
                .HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(x => x.Tags)
                    .WithMany(x => x.Posts)
                    .UsingEntity<Dictionary<string, object>>(
                        "PostTag",
                        post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                        tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                    );
        }
    }
}