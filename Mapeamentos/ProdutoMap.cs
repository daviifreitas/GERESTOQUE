using GERESTOQUE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GERESTOQUE.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.ProdutoId);
            builder.Property(produto => produto.Nome).HasMaxLength(50).IsRequired();
            builder.Property(produto => produto.Quantidade).IsRequired();
            builder.Property(produto => produto.Preco).IsRequired();

            builder.HasOne(produto => produto.Categoria).WithMany(produto => produto.produtos).HasForeignKey(produto => produto.CategoriaId).IsRequired();
            builder.HasMany(produto => produto.Movimentacoes).WithOne(produto => produto.Produto);
            builder.ToTable("produtos");
        }
    }
}
