using GERESTOQUE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GERESTOQUE.Mapeamentos
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(movimentacao => movimentacao.MovimentacaoId);
            builder.Property(movimentacao => movimentacao.Descricao).HasMaxLength(50).IsRequired();
            builder.Property(movimentacao => movimentacao.DataMovimentacao).IsRequired();

            builder.HasOne(movimentacao => movimentacao.Produto).WithMany(movimentacao => movimentacao.Movimentacoes)
                .HasForeignKey(movimentacao => movimentacao.ProdutoId).IsRequired();

            builder.ToTable("movimentacoes");
        }
    }
}
