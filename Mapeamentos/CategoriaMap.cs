using GERESTOQUE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GERESTOQUE.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(categoria => categoria.CategoriaId);
            builder.Property(categoria => categoria.Nome).HasMaxLength(30).IsRequired();

            builder.HasMany(categoria => categoria.produtos).WithOne(categoria => categoria.Categoria);
            builder.ToTable("categorias");
        }
    }
}
